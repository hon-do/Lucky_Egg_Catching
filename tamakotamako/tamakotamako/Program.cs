using System;
using Altseed2;
namespace tamakotamako
{
    class Program
    {
        static void Main(string[] args)
        {
            // エンジンを初期化
            Engine.Initialize("tamako", 1200, 800);

            // メイン画面をエンジンに追加
            Engine.AddNode(new MainNode());

            // メインループ
            while (Engine.DoEvents())
            {
                // エンジンを更新
                Engine.Update();

                // Escapeキーでゲーム終了
                if (Engine.Keyboard.GetKeyState(Key.Escape) == ButtonState.Push)
                {
                    break;
                }
            }


            // エンジンの終了処理を行う
            Engine.Terminate();

        }
    }
}
