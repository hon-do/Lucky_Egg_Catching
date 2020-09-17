using System;
using System.Collections.Generic;
using System.Text;
using Altseed2;
using System.Linq;

namespace tamakotamako
{
    // とりあえずのrectanglenodeの継承
    class Lane : RectangleNode
    {
        // 卵を生成させる時間をこっちで頑張って管理してくれ
        // カウンタ、乱数生成（テスト用）
        // 卵のデータはできればバイナリとかで保存したのを読み出したい
        int GameCounter = 0;
        Random Rnd = new System.Random();
        Player Player;

        // レーン間の距離
        readonly Vector2F Width = new Vector2F(100, 0);
        // 中心位置を設定
        public Lane(Vector2F position, Player player)
        {
            Position = position;
            Player = player;
        }

        protected override void OnAdded()
        {

        }

        protected override void OnUpdate()
        {
            // テスト用卵追加
            // カウンタが30の卵作成
            // https://baba-s.hatenablog.com/entry/2014/02/20/000000
            // 列挙型の乱数
            var random = new Random();
            // rndにleft, middle, rightのどれかがいます
            var rnd = Enum.GetValues(typeof(Pos))
                .Cast<Pos>()
                .OrderBy(c => random.Next())
                .FirstOrDefault();

            // 上の処理はこれを楽に書きたいよねで書いたもの
            //var rnd = new Random(-1, 2);
            //if (rnd == 0)
            //{
            //    var egg = new Egg(Position + Width * rnd, Player, rnd);
            //    Parent.AddChildNode(egg);
            //}..
            // elseで続けてね

            if (GameCounter % 30 == 0)
            {
                var egg = new Egg(Position + Width * ((int)rnd -1), Player ,rnd);
                Parent.AddChildNode(egg);
            }
            GameCounter++;
        }

        void MakeEgg()
        {
            // egg = new Egg(position);とかegg = new Egg(position + Width);
        }



    }
}
