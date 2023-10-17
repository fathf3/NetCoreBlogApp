namespace BlogApp.Web.ResultMessages.User
{
    public static class Messages
    {
        public static class User
        {
            public static string Add(string userName)
            {
                return $"{userName} isimli kullanıcı eklenmiştir.";
            }
            public static string Update(string userName)
            {
                return $"{userName} isimli kullanıcı güncellenmiştir.";
            }
            public static string Delete(string userName)
            {
                return $"{userName} isimli kullanıcı silinmiştir.";
            }
        }

    }
}
