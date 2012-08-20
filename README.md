これは何？
==============================

PHP の [HatenaSyntax](https://github.com/anatoo/HatenaSyntax) を [Phalanger](http://www.php-compiler.net/) でビルドして C# ではてな記法パーサを使ってみました。

主要な機能
==============================

#### はてな記法プレビュー
はてな記法で記述されたテキストファイルをプレビュー表示します。

ファイルをフォームにドラッグアンドドロップするか、コマンドライン引数に指定するかで開けます。

#### CSS
アプリのインストールディレクトリの css/style.css が存在すれば CSS として読み込まれます。

このファイルが無ければ代わりに style.default.css が読まれます。

#### 自動リロード
ツールバーの ![](HatenaView/res/icon/auto.png) を ON にすると、ファイルの更新を監視して自動的に再読み込みします。

#### 手動リロード
ツールバーの ![](HatenaView/res/icon/reload.gif) で手動でリロードを行います。自動リロードとは異なり CSS も再読み込みされます。

#### エクスポート
ツールバーの ![](HatenaView/res/icon/export.png) で HTML を出力します。

### 関連付けを開く
ツールバーの ![](HatenaView/res/icon/edit.png) でファイルに関連付けられたアプリで開きます。

エディタとかを関連付けておくといいかもしれません。

### ブラウザ起動
ツールバーの ![](HatenaView/res/icon/browser.png) でブラウザで開きます。


TODO
==============================

- CSS が作りかけなのでデフォルトでもそれなりの見栄えになるように変更する

- CSS は任意のファイルを指定出来るようにする？

- 関連付けを開くは任意のアプリを指定できるようにする

- ショートカットキー F5 とか。

- アプリにフォーカスが無いときにツールバーをクリックしてもアプリがフォアグラウンドになるだけでツールバーがクリックされたことにならない。
	- そういうものだっけ？

- HatenaSyntax に幾つかオプションがあるので指定出来るようにする？

- メインメニューの構造を整理。数が少ないのでどうてもいい気もするが

- 排他ロックしないエディタでも書き込みの瞬間に競合することがある。現状だとそのケースでもファイルが閉じられてしまうので何とかしたい
	- かなり頻繁に発生するので直ぐ治す直ぐに治す


既知のバグ
==============================
