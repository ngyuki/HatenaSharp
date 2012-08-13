using System;
using System.IO;
using PHP.Core;

static class HatenaSharp
{
	static private ScriptContext _context;

	static HatenaSharp()
	{
		_context = ScriptContext.CurrentContext;

		DeclareType(typeof(HatenaSyntax));
		DeclareType(typeof(HatenaSyntax_Renderer));
		DeclareType(typeof(HatenaSyntax_Tree));
		DeclareType(typeof(HatenaSyntax_Util));

		DeclareType(typeof(PEG));
		DeclareType(typeof(PEG_Util));
	}

	static public TextWriter Output
	{
		set
		{
			_context.Output = value;
		}
	}

	static public Stream OutputStream
	{
		set
		{
			_context.OutputStream = value;
		}
	}

	static private void DeclareType(Type type)
	{
		var desc = PHP.Core.Reflection.ClrTypeDesc.Create(type);
		_context.DeclareType(desc.PhpType.PhpTypeDesc, desc.MakeFullName());
	}

	static public string Render(string input)
	{
		var config = PhpArray.New();
		config.Add("headerlevel", 3);
		object html = HatenaSyntax.render(_context, input, config);
		return html == null ? string.Empty : html.ToString();
	}
}
