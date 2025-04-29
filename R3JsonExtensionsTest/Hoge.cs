using R3;
using R3JsonExtensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R3JsonExtensionsTest
{
    [BindableObject("hoge")]
    public class Hoge
    {
        [BindableProperty("text1")]
        public BindableReactiveProperty<string> Text1 { get; }
        [BindableProperty("int1")]
        public int Int1 { get; set; }
        [BindableProperty("environments")]
        public ObservableCollection<BindableKeyValue> Environments { get; }
        [BindableProperty("text_list1")]
        public ObservableCollection<string> TextList1 { get; }
        public ObservableCollection<string> Items { get; }
        public Hoge()
        {
            this.Text1 = new BindableReactiveProperty<string>("xxxxxx");
            this.Int1 = 123;
            this.Environments = new ObservableCollection<BindableKeyValue>();
            this.Environments.Add(new BindableKeyValue("key1", "value1"));
            this.Environments.Add(new BindableKeyValue("key2", null));
            this.TextList1 = new ObservableCollection<string>();
            this.TextList1.Add("piyo");
            this.TextList1.Add("pyontan");
            this.Items = new ObservableCollection<string>();
            this.Items.Add("ewe");
        }
    }

    public class BindableKeyValue
    {
        public BindableKeyValue(string? key, string? value)
        {
            this.Key = new BindableReactiveProperty<string?>(key);
            this.ValueDayo = value;
        }
        public BindableKeyValue() : this(null, null)
        {

        }
        [BindableProperty("key")]
        public BindableReactiveProperty<string?> Key { get; }
        [BindableProperty("value_dayo")]
        public string? ValueDayo { get; }
    }
}