using System;
using System.Collections.Generic;
using System.Text;
using Altseed2;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace tamakotamako
{
    enum Pos
    {
        Left,
        Middle,
        Right,
    }

    class MainNode : Node
    {
        // キャラクターを表示するノード
        private Node characterNode = new Node();

        // プレイヤーの参照
        private Player player;


        // スコアを表示するノード
        public TextNode scoreNode;



        // エンジンに追加された時に実行
        protected override void OnAdded()
        {
            // キャラクターノードを追加
            AddChildNode(characterNode);

            // UIを表示するノード
            var uiNode = new Node();

            // UIノードを追加
            AddChildNode(uiNode);

            //// 背景に使用するテクスチャ
            //var backTexture = new SpriteNode();
            //// 背景のテクスチャを読み込む
            //backTexture.Texture = Texture2D.LoadStrict("Resources/Background.png");
            //// 表示位置を奥に設定
            //backTexture.ZOrder = -100;
            //// 背景テクスチャを追加
            //AddChildNode(backTexture);

            // プレイヤーを設定
            player = new Player(new Vector2F(600, 460));
            var lane = new Lane(player.Position + new Vector2F(0, -400), player);

            // キャラクターノードにプレイヤーを追加
            characterNode.AddChildNode(player);
            characterNode.AddChildNode(lane);


            // スコアを表示するノードを設定
            scoreNode = new TextNode();
            // スコア表示に使うフォントを読み込む
            scoreNode.Font = Font.LoadDynamicFontStrict("Resources/font.ttf", 30);
            // スコア表示の位置を設定
            scoreNode.Position = new Vector2F();
            // スコア表示の文字を設定
            scoreNode.Text = "スコア" + player.Score;

            // UIノードにスコア表示ノードを追加
            uiNode.AddChildNode(scoreNode);
        }

        protected override void OnUpdate()
        {
            // スコア表示の文字を設定
            scoreNode.Text = "スコア" + player.Score;
        }
    }


}
