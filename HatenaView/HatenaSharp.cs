using System;
using System.IO;
using PHP.Core;

static class HatenaSharp
{
	static private ScriptContext _context;

	static HatenaSharp()
	{
		_context = ScriptContext.CurrentContext;

		DeclareType(_context, typeof(HatenaSyntax));
		DeclareType(_context, typeof(HatenaSyntax_Renderer));
		DeclareType(_context, typeof(HatenaSyntax_Tree));
		DeclareType(_context, typeof(HatenaSyntax_Util));
		DeclareType(_context, typeof(PEG));
		DeclareType(_context, typeof(PEG_Util));
	}

	private static void DeclareType(ScriptContext ctx, Type type)
	{
		var desc = PHP.Core.Reflection.ClrTypeDesc.Create(type);

		ctx.DeclareType(desc.PhpType.PhpTypeDesc, desc.MakeFullName());
	}

	public static TextWriter Output
	{
		set
		{
			_context.Output = value;
		}
	}

	public static Stream OutputStream
	{
		set
		{
			_context.OutputStream = value;
		}
	}

	public static string Render(string input)
	{
		/*
		 * 何故か fork しないと以下の条件で PEG_Util などが undefined になります。
		 * 
		 * - 起動後にドラッグアンドドロップでファイルを開いた（1 回だけ）
		 * - ファイル監視を有効にしてファイルの内容を編集した
		 * - 直後に PEG_Util undefined になる
		 * 
		 * 起動後にドラッグアンドドロップを 2 回行うと undefined にはなりません。
		 * ファイル監視のイベントは UI スレッドにマーシャリングされているはずですが、
		 * .NET のスレッドはネイティブのスレッドと実は一致しないらしいので
		 * その辺に問題があるのかもしれません。
		 * 
		 * とりあえず毎回 fork すれば大丈夫そうです。
		 */

		//var ctx = _context;
		var ctx = _context.Fork();
		
		var config = PhpArray.New();

		config.Add("headerlevel", 3);

		object html = HatenaSyntax.render(ctx, input, config);

		return html == null ? string.Empty : html.ToString();
	}
}
