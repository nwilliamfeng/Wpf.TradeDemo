using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Demo
{
    public class OperatorRecordViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //todo--详细命令
        public ICommand DetailCommand { get; set; }


        //todo-- 线下成交命令
        public ICommand OfflineDealCommand { get; set; }

        private ObservableCollection<OperatorRecordItemViewModel> _items = new ObservableCollection<OperatorRecordItemViewModel>();

        public ICollectionView Items { get; private set; }


        public OperatorRecordViewModel()
        {
            this._items = new ObservableCollection<OperatorRecordItemViewModel>(this.CreateItems());
            this.Items = CollectionViewSource.GetDefaultView(this._items);
          
        }

        private IEnumerable<OperatorRecordItemViewModel> CreateItems()
        {
            yield return new OperatorRecordItemViewModel { Code = "190004.IB", Px = 2.975m, Offset = 1, OperatorA = "陈天伟", OperatorB = "张腾", NameB = "四川信托-北京（龚三四）" };
            yield return new OperatorRecordItemViewModel { Code = "190004.IB", Px = 2.975m, Offset = 1, OperatorA = "张腾", OperatorB = "张腾", NameB = "四川信托-北京（龚三四）" };
            yield return new OperatorRecordItemViewModel { Code = "190205.IB", Px = 3.68m, Vol = 1, OperatorA = "张腾", OperatorB = "兰凯", NameB = "苏州农商行(许成涵)" ,IsGVN= true,IsEnable=true};
            yield return new OperatorRecordItemViewModel { Code = "190004.IB", Px = 2.975m, Offset = 1, OperatorA = "张腾", OperatorB = "张腾", NameB = "四川信托-北京（龚三四）" };
        }
     
    }

    public class OperatorRecordItemViewModel : INotifyPropertyChanged
    {
        public string Code { get; set; }

        public decimal Px { get; set; }

        public int Vol { get; set; }

        public int Offset { get; set; } = 1;

        public DateTime Time { get; set; } = DateTime.Now;

        public bool IsEnable { get; set; }

        public string NameA { get; set; }

        public string NameB { get; set; }

        public string OperatorA { get; set; }

        public string OperatorB { get; set; }


        public bool IsGVN { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
