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
        private KwisspelEntities _context;

        private Category _category;

        public int Id {
            get {return _category.id; }
            set { _category.id = value; RaisePropertyChanged("Id"); }
        }

        public string Name
        {
            get { return _category.name; }
            set { _category.name = value; RaisePropertyChanged("Name"); }
        }

        public Category Model
        {
            get { return _category; }
        }

        public CategoryViewModel(Category c, KwisspelEntities context)
        {
            _context = context;
            _category = c;
        }

        public CategoryViewModel()
        {
            _category = new Category();
        }

    }
}
