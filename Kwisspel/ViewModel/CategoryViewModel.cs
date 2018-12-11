using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwisspel.ViewModel
{
   public class CategoryViewModel : ViewModelBase
    {

        private Category _category;

        public int Id {
            get {return _category.id; }
            set { _category.id = value; RaisePropertyChanged(); }
        }

        public string Name
        {
            get { return _category.name; }
            set { _category.name = value; RaisePropertyChanged(); }
        }

        public Category Model
        {
            get { return _category; }
        }

        public CategoryViewModel(Category c)
        {
            _category = c;
        }

        public CategoryViewModel()
        {
            _category = new Category();
        }

    }
}
