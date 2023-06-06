using log4net;
using log4net.Config;

namespace Service.Helpers
{
    /// <summary>
    /// Класс для логгирования событий
    /// </summary>
    public class Logger
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Logger));

        public static ILog Log
        {
            get { return log; }
        }

        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }

        
        public const string InfoMessage01 = "IIN is not valid (Неверный ИИН)";

        public const string ErrorMessage01 = "Ошибка сохранения в БД.";
        public const string ErrorMessage02 = "Проверка сертификата на валидность: FALSE.";
        public const string ErrorMessage03 = "Ошибка десериализации Xml.";
        public const string ErrorMessage04 = "Проверка подписи на валидность: FALSE.";

        public const string ResponseMessage01 = "Ошибка проверки ЭЦП";
    }
}