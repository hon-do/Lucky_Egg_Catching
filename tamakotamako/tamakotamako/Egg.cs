using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Altseed2;

namespace tamakotamako
{
    class Egg : SpriteNode
    {
        Pos EnumPosition;

        Player Player;

        Vector2F Speed = new Vector2F(0, 10);
        Vector2F EggScale = new Vector2F(0.08f, 0.08f);

        float CollideRange = 13.0f;

        public Egg(Vector2F position, Player player, Pos pos) : base()
        {
            // 卵のテクスチャを読み込む
            Texture = Texture2D.LoadStrict("Resources/tamago.png");
            Position = position;
            CenterPosition = ContentSize / 2;
            Scale = EggScale;
            Player = player;
            EnumPosition = pos;
        }

        protected override void OnUpdate()
        {
            // 下にずらす
            Position += Speed;

            // 画面外に出たら消去
            RemoveMyselfIfOutOfWindow();

            // もしy座標が衝突okでPlayer.EnumとEgg.Enumが等しいなら衝突            
            if (EnumPosition == Player.Player_0 &&
                Position.Y - CollideRange < Player.Position.Y &&
                Position.Y + CollideRange > Player.Position.Y)
            {
                OnCatchedDestroy();
            }

        }
        // 画面外に出た時自身を消去
        private void RemoveMyselfIfOutOfWindow()
        {
            var halfSize = Texture.Size / 2;
            if (Position.X < -halfSize.X
                 || Position.X > Engine.WindowSize.X + halfSize.X
                 || Position.Y < -halfSize.Y
                 || Position.Y > Engine.WindowSize.Y + halfSize.Y)
            {
                // 自身を削除
                Parent?.RemoveChildNode(this);
            }
        }

        public void OnCatchedDestroy()
        {
            //特定のフレーム内（or距離）にいた時、playerのx軸と卵のx軸が一致していることがあったら卵を消す
            Parent?.RemoveChildNode(this);            
            Player.OnCollide();

         }
    }
}
