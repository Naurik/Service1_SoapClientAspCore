namespace Service.Helpers.Extensions{

	public static class DateExt{

		public static string ToDateTimeString(this DateTime date){
			return date.ToString("dd.MM.yyyy HH:mm:ss");
		}

	}
}
