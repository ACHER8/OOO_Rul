using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OOO_Rul
{
    public static class  Pages
    {
        static Db db;
        static Dictionary<PageType, Page> pages = new Dictionary<PageType, Page>();
        static Dictionary<PageType, (Type, Type)> pageTypes = new Dictionary<PageType, (Type, Type)>();
        public static event EventHandler<PageType> CurrentPageChanged;
        public static void RegisterPageType(PageType type, Type pageType, Type vmType)
        {
            if (pageTypes.ContainsKey(type))
                throw new Exception("Заданный тип страницы уже зарегистрирован");
            pageTypes.Add(type, (pageType, vmType));
        }
        public static void SetModel(Db, db)
        {
            Pages.db = db;
        }

        static Pages()
        {
            RegisterPageType(PageType.PageRulList, typeof(PageRulList), typeof(VMRulList));

        }
        public static void ChangedPageTo(PageType type)
        {
            CurrentPageChanged?.Invoke(null, type);
        }

    }
}
