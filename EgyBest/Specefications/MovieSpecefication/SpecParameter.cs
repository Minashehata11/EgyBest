namespace EgyBest.Infrastructure.Specefications.MovieSpecefication
{
    public class SpecParameter
    {
        public int? DirectorId { get; set; }
        public string? Sort { get; set; }
        private int pageSize = 5;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value > 10 ? 10 : value; }
        }

        public int PageIndex { get; set; } = 1;
        private string? serach;

		public string? Search
		{
			get { return serach; }
			set { serach = value?.ToLower().Trim(); }
		}

	}
}
