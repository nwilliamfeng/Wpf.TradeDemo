using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class MainViewModel : INotifyPropertyChanged
    {

        public MainViewModel()
        {

            var trade1 = new Trade { Code = "180210.IB", Name = "18国开10 9.01Y" };
            trade1.Gvns.Add(new TradeItem { DealPrice = 3.785m });
            trade1.Gvns.Add(new TradeItem { DealPrice = 3.77m });
            trade1.Tkns.Add(new TradeItem { DealPrice = 3.76m });
            trade1.Tkns.Add(new TradeItem { DealPrice = 3.75m });
            var trade2 = new Trade { Code = "190205.IB", Name = "19国开05 9.52Y" };
            trade2.Gvns.Add(new TradeItem { DealPrice = 3.685m });
            trade2.Gvns.Add(new TradeItem { DealPrice = 3.68m });
            trade2.Tkns.Add(new TradeItem { DealPrice = 3.6775m });
            trade2.Tkns.Add(new TradeItem { DealPrice = 3.675m });
            var trade3 = new Trade { Code = "190210.IB", Name = "19国开10 9.88Y" };
            trade3.Gvns.Add(new TradeItem { DealPrice = 3.5425m });
            trade3.Gvns.Add(new TradeItem { DealPrice = 3.54m });
            trade3.Tkns.Add(new TradeItem { DealPrice = 3.535m });
            trade3.Tkns.Add(new TradeItem { DealPrice = 3.53m });

            this.Trades.Add(trade1);
            this.Trades.Add(trade2);
            this.Trades.Add(trade3);
            var deals = GetDeals().ToList();
            this.Trades.SelectMany(x => x.Gvns)
                .ToList()
                .ForEach(t => deals.Where(x => x.DealPrice == t.DealPrice && x.IsGVNDeal).ToList().ForEach(x => t.Deals.Add(x)));
            this.Trades.SelectMany(x => x.Tkns)
               .ToList()
               .ForEach(t => deals.Where(x => x.DealPrice == t.DealPrice && !x.IsGVNDeal).ToList().ForEach(x => t.Deals.Add(x)));

        }

        public ObservableCollection<Trade> Trades { get; set; } = new ObservableCollection<Trade>();


        public string Account { get; set; } = "tzhang@tp.com";

        public string Server { get; set; } = "192.145.23.564";

        public DateTime Time { get; set; } = DateTime.Now;

        public bool IsConnected { get; set; } = true;


        public event PropertyChangedEventHandler PropertyChanged;

        private IEnumerable<Deal> GetDeals()
        {
            yield return new Deal { DealPrice = 3.785m, Name = "TTFF", OperatorA = "张腾", OperatorB = "张腾",IsOperatorActive=true,DealCount=1000,IsGVNDeal=true };
            yield return new Deal { DealPrice = 3.77m, Name = "大连银行周水子分公司", OperatorA = "徐思文", OperatorB = "林梦珍", DealCount = 1000, IsGVNDeal = true };
            yield return new Deal { DealPrice = 3.76m, Name = "齐鲁银行", OperatorA = "夏侯艳霞", OperatorB = "王苑", DealCount = 2000 };
            yield return new Deal { DealPrice = 3.75m, Name = "中国人寿保险公司", OperatorA = "李月", OperatorB = "龚玥", DealCount = 5000 };
            yield return new Deal { DealPrice = 3.75m, Name = "大连银行周水子分公司", OperatorA = "李哲", OperatorB = "林梦珍", DealCount = 2000 };
            yield return new Deal { DealPrice = 3.76m, Name = "汇丰静信浦东分行", OperatorA = "高萌", OperatorB = "王颖欣", DealCount = 1000, OffSetEnable=true, };


            yield return new Deal { DealPrice = 3.5425m, Name = "辽宁新民", OperatorA = "付菊森", OperatorB = "吴昊宇",  DealCount = 3000, IsGVNDeal = true };
            yield return new Deal { DealPrice = 3.54m, Name = "昆山农商行", OperatorA = "徐思文", OperatorB = "兰蔻", DealCount = 3000, IsGVNDeal = true };
            yield return new Deal { DealPrice = 3.54m, Name = "齐鲁银行", OperatorA = "周飞", OperatorB = "张弛", DealCount = 2000, IsGVNDeal = true };
            yield return new Deal { DealPrice = 3.535m, Name = "AAA", OperatorA = "陈天宇", OperatorB = "孙佳宝", DealCount = 5000 };
            yield return new Deal { DealPrice = 3.53m, Name = "FFF", OperatorA = "张腾", OperatorB = "孙晓宇", DealCount = 2000 };

            yield return new Deal { DealPrice = 3.685m, Name = "南宫农商行", OperatorA = "安兆航", OperatorB = "王苑", DealCount = 3000, IsGVNDeal = true };
            yield return new Deal { DealPrice = 3.68m, Name = "汇添富基金", OperatorA = "廖文熙", OperatorB = "张凯悦", DealCount = 3000, IsGVNDeal = true };
            yield return new Deal { DealPrice = 3.6775m, Name = "南方基金-嘉实", OperatorA = "刘诗梦", OperatorB = "李鼎超", DealCount = 4000 };
            yield return new Deal { DealPrice = 3.6775m, Name = "凤县农商行", OperatorA = "周林", OperatorB = "万依林", DealCount = 4000 };
            yield return new Deal { DealPrice = 3.675m, Name = "国信证券国兰", OperatorA = "郑好", OperatorB = "兰凯", DealCount = 2000 };
            yield return new Deal { DealPrice = 3.675m, Name = "AAA", OperatorA = "周佳", OperatorB = "张弛", DealCount = 2000 };
        }
    }
}
