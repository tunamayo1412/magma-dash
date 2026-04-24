# はじめに
- このリポジトリは「ツナマヨ」（Xアカウント：@tunamayo1412）が制作したゲーム「マグマダッシュ！」に関するものです
- ご利用いただくことでのトラブル等は一切責任を負いかねます

# ソースコード
- 本プロジェクトの主要なプログラム（C#スクリプト）は `Assets/Scripts` 内に格納されています

# コンセプト
- ゲーム制作のためのプログラミングスキルを身につけるために、ゲームを1週間で制作するというコンセプトのイベントである「Unity1週間ゲームジャム」に参加しました
- お題「あつい」を基にどのようなゲームを作れるか考えた結果、Minecraftにおいてマグマの上にある足場を転々と走り抜けるアスレチックを思い出し、それに似たゲームを制作しようと考えました
- 自然なランダムマップ生成のためにパーリンノイズを用いました
```C#:MapCreator.cs
    void MapCreate() {
        parent = new GameObject("Enpty object");
        parent.AddComponent<ParentScript>();
        parent.transform.position = new Vector3(0, 0, z);
        z++;
        for (x = 0; x <= mapX; x++) {
            GameObject cube;
            float xSample = (x + random) / relief;
            float zSample = (z + random) / relief;
            float perlin = Mathf.PerlinNoise(xSample, zSample);
            float y = maxHeight * perlin;
            y = Mathf.Round(y);
            if (y <= 1f) {
                cube = Instantiate(magma);
            } else if(y == 2){
                cube = Instantiate(rock_1);
            } else {
                cube = Instantiate(rock_2);
                GameObject Crystal = Instantiate(crystal);
                Crystal.transform.SetParent(parent.transform);
                Crystal.transform.localPosition = new Vector3(x, y, 0);
                y -= 1;
            }
            cube.transform.SetParent(parent.transform);
            cube.transform.localPosition = new Vector3(x, y, 0);
        }
    }
```

# ゲーム概要
- マグマに落ちないようにランダムに生成される足場をジャンプで渡り歩き、スコアアイテムを獲得するゲームです

# デモ動画
<img src="https://raw.githubusercontent.com/wiki/tunamayo1412/magma-dash/magmaDash.gif" width="500">
<img src="https://raw.githubusercontent.com/wiki/tunamayo1412/magma-dash/magmaDash_map.gif" width="500">

# 環境
- 開発言語：C#
- アプリケーション：Unity 2018.2.6f1
- 検証済みOS：Windows 10 Home 22H2

# 利用方法
- Unity 2018.2.6f1で本プロジェクトを起動してください
- また、UnityRoom上でもプレイすることが出来ます：<https://unityroom.com/games/magmadash>

# 操作方法
- 移動：WASD
- 視点：マウス
- ダッシュ：左Shift
- ジャンプ：Space

# おわりに
- ゲーム制作のポートフォリオとしてリポジトリ公開させていただきました 
- 感想・コメント等あればご連絡下さると幸いです
