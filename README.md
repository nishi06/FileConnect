# FileConnect

# LogOperate クラス
 LogOperate はログファイルの操作を行うクラスです。

# コンストラクター
## Log()
 インスタンスを初期化します。
### 使用例
```
FileConnect.LogOperate log = new FileConnect.LogOperate();
```

## Log(string fileName, Boolean isAppend, Encoding encoding)
 ファイル名、追記モード/上書きモード、エンコーディングを指定してインスタンス化を行います。
 パラメーターは下記となります。
 + fileName : String型です。書き込みを行うファイル名を絶対パスで指定します。
 + isAppend : Boolean型です。ファイルに対し追記するか上書きするかを制御します。trueは追記、falseは上書きとなります。
 + encoding : Encoding型です。書き込みの際に扱うエンコーディングを指定します。
### 使用例
```
FileConnect.LogOperate log = new FileConnect.LogOperate(@"D:\Log\" + DateTime.Now.ToString("yyyyMMdd-HHmmss")+".log", true, Encoding.UTF8);
```

# プロパティ
## FileName
 String型です。書き込みを行うファイル名を絶対パスで指定します。
## IsAppend
 Boolean型です。ファイルに対し追記するか上書きするかを制御します。true:追記、false:上書き。
## Encoding
 Encoding型です。書き込みの際に扱うエンコーディングを指定します。

### 使用例
```
FileConnect.LogOperate log = new FileConnect.LogOperate();
log.FileName = @"D:\Log\" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".log";
log.IsAppend = false;
log.Encoding = Encoding.ASCII;
```

# メソッド
## void Write(string format, params object[] args)
### 概要
 ファイルに文字列を書き込みます。
### 引数
 + format
  string型です。フォーマットを指定します。
 + args
  object型の可変長引数です。Formatパラメーター内にエスケープ文字を入れた場合はそれに対応する値を指定します。
### 戻り値
 無し
### 使用例
```
FileConnect.LogOperate log = new FileConnect.LogOperate(@"D:\Log\" + DateTime.Now.ToString("yyyyMMdd-HHmmss")+".log", true, Encoding.UTF8);
log.Write("This is test. ");
log.Write("Format test1 Value1:{0} Value2:{1}. ", 10, 11);
object[] value = new object[2];
value[0] = 12;
value[1] = 13;
log.Write("Format test2 Value1:{0} Value2:{1}. ", value); 
```
上記のコードを実行するとファイルには下記のように書き込まれます。
```
This is test. Format test1 Value1:10 Value2:11. Format test2 Value1:12 Value2:13. 
```

## void WriteLine(string format, params object[] args)
### 概要
 ファイルに行単位で文字列を書き込みます。
### 引数
 + format
  string型です。フォーマットを指定します。
 + args
  object型の可変長引数です。Formatパラメーター内にエスケープ文字を入れた場合はそれに対応する値を指定します。
### 戻り値
 無し
### 使用例
```
FileConnect.LogOperate log = new FileConnect.LogOperate();
log.FileName = @"D:\Log\" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".log";
log.IsAppend = true;
log.Encoding = Encoding.ASCII;
log.WriteLine("This is test. ");
log.WriteLine("Format test1 Value1:{0} Value2:{1}. ", 14, 15);
object[] value = new object[2];
value[0] = 16;
value[1] = 17;
log.WriteLine("Format test2 Value1:{0} Value2:{1}. ", value);
```
上記のコードを実行するとファイルには下記のように書き込まれます。
```
This is test. 
Format test1 Value1:14 Value2:15. 
Format test2 Value1:16 Value2:17. 
```

## void FileOpen()
### 概要
 FileNameプロパティに設定したファイルを起動します。
 ※お使いのウイルスセキュリティソフトが有効になっている場合、ファイルを起動すると削除されることがあります。この場合はウイルスセキュリティソフトの設定を一部解除しておく必要があります。
### 引数
 無し
### 戻り値
 無し
 
# 使用例
```
FileConnect.LogOperate log = new FileConnect.LogOperate();
log.FileName = @"D:\Log\" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".log";
log.IsAppend = true;
log.Encoding = Encoding.ASCII;
log.WriteLine("This is test. ");
log.FileOpen();
```
上記のコードを実行するとFileNameプロパティで指定したlogファイルを起動します。
ログファイルには「This is test.」と記載されています。 