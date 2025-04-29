using R3JsonExtensions;
using System.Text.Json.Nodes;

namespace R3JsonExtensionsTest
{
    public class ExtensionTests
    {
        [Fact]
        public void ToJsonObject_Should_Serialize_Hoge_Correctly()
        {
            // Arrange
            var original = new Hoge();

            // Act
            JsonObject? json = original.ToJsonObject();

            // Assert JSON 構造
            Assert.NotNull(json);
            Assert.True(json!.ContainsKey("hoge"));

            var root = json["hoge"] as JsonObject;
            Assert.NotNull(root);

            // 単純プロパティ
            Assert.Equal("xxxxxx", root!["text1"]!.GetValue<string>());
            Assert.Equal(123, root["int1"]!.GetValue<int>());

            // ネスト配列 (BindableKeyValue)
            var envs = root["environments"] as JsonArray;
            Assert.NotNull(envs);
            Assert.Equal(2, envs!.Count);

            var first = envs[0] as JsonObject;
            Assert.NotNull(first);
            Assert.Equal("key1", first!["key"]!.GetValue<string>());
            Assert.Equal("value1", first["value_dayo"]!.GetValue<string>());

            var second = envs[1] as JsonObject;
            Assert.NotNull(second);
            Assert.Equal("key2", second!["key"]!.GetValue<string>());
            Assert.Equal((string?)null, second["value_dayo"]?.GetValue<string?>());

            // 文字列コレクション
            var texts = root["text_list1"] as JsonArray;
            Assert.NotNull(texts);
            Assert.Equal(2, texts!.Count);
            Assert.Equal("piyo", texts[0]!.GetValue<string>());
            Assert.Equal("pyontan", texts[1]!.GetValue<string>());

            // Items プロパティは BindablePropertyAttribute がないため出力されない
            Assert.False(root.ContainsKey("Items"));
        }

        [Fact]
        public void SetJsonObject_Should_Restore_Hoge_Correctly()
        {
            // Arrange: 元のインスタンス
            var original = new Hoge();

            // JSON に変換
            JsonObject? json = original.ToJsonObject();
            Assert.NotNull(json);

            // Arrange2: まっさらなインスタンスを用意
            var recreated = new Hoge();
            recreated.Text1.Value = "";      // 初期値空に
            recreated.Int1 = 0;              // 初期値ゼロに
            recreated.Environments.Clear();  // 空に
            recreated.TextList1.Clear();     // 空に

            // Act: JSON から復元
            recreated.SetJsonObject(json);

            // Assert: 元と同じ値に復元されていること
            Assert.Equal("xxxxxx", recreated.Text1.Value);
            Assert.Equal(123, recreated.Int1);

            // Environments の中身
            Assert.Equal(2, recreated.Environments.Count);
            Assert.Equal("key1", recreated.Environments[0].Key.Value);
            Assert.Equal("value1", recreated.Environments[0].ValueDayo);
            Assert.Equal("key2", recreated.Environments[1].Key.Value);
            Assert.Equal((string?)null, recreated.Environments[1].ValueDayo);

            // TextList1 の中身
            Assert.Equal(2, recreated.TextList1.Count);
            Assert.Equal("piyo", recreated.TextList1[0]);
            Assert.Equal("pyontan", recreated.TextList1[1]);
        }
    }
}