namespace BlogApp.Web.ResultMessages.Category
{
    public static class Messages
    {
        public static class Category
        {
            public static string Add(string categoryName)
            {
                return $"{categoryName} kategorisi eklenmiştir.";
            }
            public static string Update(string categoryName)
            {
                return $"{categoryName} kategorisi güncellenmiştir.";
            }
            public static string Delete(string categoryName)
            {
                return $"{categoryName} kategorisi silinmiştir.";
            }
            public static string UndoDelete(string categoryName)
            {
                return $"{categoryName} kategorisi geri yüklenmiştir.";
            }
        }

    }
}
