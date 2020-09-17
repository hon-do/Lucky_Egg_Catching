using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Altseed2;

namespace tamakotamako
{
    class Player : SpriteNode
    {
        public Pos Player_0;
        // 初期位置(真ん中)
        Vector2F MiddlePosition;

        // 左右移動率
        readonly Vector2F MoveWidth = new Vector2F(100, 0);

        Vector2F PlayerScale = new Vector2F(0.4f, 0.4f);


        public Player(Vector2F v)
        {
            // 自機のテクスチャを読み込む
            Texture = Texture2D.LoadStrict("Resources/lucky.png");
            // 自機の座標を設定
            Position = v;
            // 自機の中心座標を設定
            CenterPosition = ContentSize / 2;
            // MiddlePosition設定
            MiddlePosition = v;
            // 大きさ
            Scale = PlayerScale;
        }

        // 点数
        public int Score { private set; get; }  = 0;

        // enumで左、真ん中、右状態を持たせる
        // https://docs.microsoft.com/ja-jp/dotnet/csharp/language-reference/builtin-types/enum


        // 卵側から衝突の呼び出し
        public void OnCollide()
        {
            Score++;
        }

        protected override void OnAdded()
        {

        }

        protected override void OnUpdate()
        {
            // キー入力の例 
            //// Zキーが押された時に実行
            //if (Engine.Keyboard.GetKeyState(Key.Z) == ButtonState.Push)
            // if enumが右 && 左を押す -> enumを真ん中
            // else if enum 左を押す -> enumを左
            // if enumが左 && 右を押す -> enumを真ん中
            // else if enum 右を押す -> enumを右
            // else if 押していない -> 真ん中

            // 真ん中を経由する処理
            // player_0じゃね？
            switch (Player_0)
            {
                // case Pos.Middleだけでよい
                case Pos.Middle:
                    if (Engine.Keyboard.GetKeyState(Key.Left) == ButtonState.Hold)
                    {
                        Player_0 = Pos.Left;
                    }
                    else if (Engine.Keyboard.GetKeyState(Key.Right) == ButtonState.Hold)
                    {
                        Player_0 = Pos.Right;
                    }

                    break;

                case Pos.Left:
                    if (Engine.Keyboard.GetKeyState(Key.Left) == ButtonState.Hold)
                    {
                        Player_0 = Pos.Left;
                    }
                    //else if (Engine.Keyboard.GetKeyState(Key.Right) == ButtonState.Push)
                    //{
                    // shotメソッド
                    //    Player_0 = Pos.Middle;
                    //}
                    else
                    {
                        //押してないなら真ん中なんだよ。shotめ。
                        Player_0 = Pos.Middle;
                    }
                    break;

                case Pos.Right:
                    if (Engine.Keyboard.GetKeyState(Key.Right) == ButtonState.Hold)
                    {
                        Player_0 = Pos.Right;
                    }
                    //else if (Engine.Keyboard.GetKeyState(Key.Left) == ButtonState.Push)
                    //{
                    //    Player_0 = Pos.Middle;
                    //}
                    else
                    {
                        //押してないなら真ん中なんだよ。shotめ。
                        Player_0 = Pos.Middle;
                    }
                    break;
            }

            switch(Player_0)
            {
                // player自体の位置は Position
                case Pos.Left:
                    Position = MiddlePosition - MoveWidth;
                    break;
                case Pos.Middle:
                    Position = MiddlePosition;
                    break;
                case Pos.Right:
                    Position = MiddlePosition + MoveWidth;
                    break;
            }
        }
        // 卵はlaneが保持して、卵側で当たり判定。。
    }


}
