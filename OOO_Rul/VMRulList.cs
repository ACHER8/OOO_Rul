using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOO_Rul
{
    internal class VMRulList:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        Db db;
        private ProductClass selectedProdectClass;
        public ObservableCollection<ModelClass> ModelClasc { get; set; }

        public ProductClass SelectedProdectClass
        {
            get => selectedProdectClass; set
            {
                selectedProdectClass = value;
                SignalChanged();
            }
        }
        public CustomCommand CreateProductClass { get; set; }
        public CustomCommand DeleteProductClass { get; set; }
        public CustomCommand SaveProductClass { get; set; }
        public CustomCommand Refresh { get; set; }
        public CustomCommand OpenCreateProductClass { get; set; }

        public VMRulList()
        {
            db = Db.GetDb();
            LoadProductClass();
            OpenCreateProductClass = new CustomCommand(() =>
            {
                new WinProductClassCreate().Show();
            });

            CreateProductClass = new CustomCommand(() =>
            {
                SelectedProdectClass = new ProductClass { /*Name = "название"*/ };
                db.ProductClasc.Add(SelectedProdectClass);
                LoadProductClass();
            });



        }

        private void LoadProductClass()
        {
        }

        void SignalChanged([CallerMemberName] string prop = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
