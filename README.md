

# setup

Ubuntu 22.04 LTE

## 1. Unity のインストール（Ubuntu 22）

### 1-1. 必要パッケージ

ターミナルで：

```bash
sudo apt update
sudo apt install -y libgtk2.0-0 libgconf-2-4 libnss3 libasound2 \
    libxtst6 libxi6 libxrandr2 libxss1 libglu1-mesa
```

（足りないと言われたら、その都度 `sudo apt install xxxx` で追加してOK）

---

### 1-2. Unity Hub (AppImage) をダウンロード

[https://unity.com/download](https://unity.com/download)
 
```sh
# 1. 公開鍵を登録
wget -qO - https://hub.unity3d.com/linux/keys/public \
  | gpg --dearmor \
  | sudo tee /usr/share/keyrings/Unity_Technologies_ApS.gpg > /dev/null

# 2. リポジトリを追加
sudo sh -c 'echo "deb [signed-by=/usr/share/keyrings/Unity_Technologies_ApS.gpg] https://hub.unity3d.com/linux/repos/deb stable main" \
  > /etc/apt/sources.list.d/unityhub.list'

# 3. パッケージリスト更新＆Hubをインストール
sudo apt update
sudo apt install unityhub
```


- 起動：
```bash
unityhub
```

初回起動で「ログイン」求められるので、Unity アカウントを作成 or ログイン。

---

### 1-3. Editor のインストール

Unity Hub の中で：

1. 左メニュー **Installs（インストール）**
2. **Install Editor** → LTS（例：`6000.x LTS` とか）を選択
3. モジュールはひとまず

   * **Linux Build Support**（任意、PCで動かすだけなら不要）
   * **Web Build Support**

4. Install を押す

※ インストールが終わるまで待てば OK（裏で勝手にやってくれる）

---

## 2. 新しい 3D プロジェクトを作る

Unity Hub で：

1. 左上 **Projects（プロジェクト） → New project**
2. Template: **3D（URP でもどっちでもOK。シンプルなら 3D）**
3. プロジェクト名：例 `CubeSample`
4. 保存場所を選んで **Create project**

数十秒〜数分で Unity Editor が起動するはず。

---

## 3. シーンに立方体（Cube）を置く

Unity Editor 上で：

1. 上のメニューから
   `GameObject` → `3D Object` → `Cube`
2. Hierarchy に `Cube` が追加され、Scene 画面に白い立方体が出る
3. `Cube` を選択した状態で `Inspector` から位置を確認

   * `Transform`

     * Position: (0, 0, 0) 程度でOK

カメラが見える位置に来ていなければ、
**Scene ビューで `Cube` を右クリック → Frame Selected (F)** で寄れます。

---

## 4. 立方体をスクリプトで動かす

### 4-1. スクリプトを作成

1. Project ウィンドウで `Assets` を右クリック →
   `Create` → `C# Script`
2. 名前を `MoveCube` にする
3. `Cube` を選択し、Inspector の下にある **Add Component** を押して
   `MoveCube` と入力 → 追加
### 4-2. スクリプト編集

`MoveCube` のアイコンをダブルクリックするとエディタ（VS Codeなど）が開きます。
中身を以下のように変更：

```csharp
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public float speed = 1.0f;

    void Update()
    {
        // Z方向に前進し続ける
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }
}
```

保存（Ctrl+S）。

Unity に戻ると自動でコンパイルされます。

---

## 5. 実行して動作確認

1. 上中央の **▶（再生ボタン）** を押す
2. Gameビューで **Cube が手前に向かってスーッと動く** はず

速度を変えたい場合は：

* `Cube` を選択 → Inspector の `MoveCube` コンポーネントの
  `Speed` を 2 や 5 に変えて再生

---

## 6. ここから先の発展例（軽く）

* スペースキーで前進・停止を切り替え
* マウス入力で回転
* 外部データ（CSVやソケット）から位置を読み込んで再生
* 将来：ROS2 からのトピックを受け取って可視化

とか、全部この延長でできます。

---

もしこの手順で、

* Unity Hub 起動しない
* Editor が出てこない
* 依存パッケージエラー

みたいなのが出たら、**出たエラーそのまま貼ってくれれば、Ubuntu22向けに一緒に直していきます**。
# unity_viewer
