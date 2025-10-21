using Address_Finder.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Address_Finder_DotNetFrameWork
{
    public class Address_Finder
    {
        private string api_key = string.Empty;
        private ResponseModel _last_response;

        private string base_url = "https://business.juso.go.kr/addrlink/addrLinkApi.do?";
        private int count_per_page = 10;
        private int _total_page = 0;
        private string _keyword = string.Empty;
        public string KEYWORD { get { return _keyword; } set { _keyword = value; } }

        public int TOTAL_PAGE
        {
            get { return _total_page; }
            set { _total_page = value; }
        }
        public int CURRENT_PAGE
        {
            get { return (_last_response != null) ? _last_response.results.common.currentPage : 0; }
        }
        public Address_Finder(string API_KEY)
        {
            api_key = API_KEY;
        }

        public List<juso> GetAddress(string keyword)
        {
            List<juso> list = new List<juso>();
            //string url = base_url+$"confmKey={api_key}&currentPage=1&countPerPage={count_per_page}&keyword={keyword}&resultType=json";
            var response = GetData(keyword);
            if (response == null) { return list; }
            list = response.results.Juso;
            int total_page = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(response.results.common.totalCount) / count_per_page));
            _total_page = total_page;
            //CURRENT_PAGE = 1;

            return list;
        }

        public List<juso> MovePage(int page)
        {
            List<juso> list = new List<juso>();
            //string url = base_url + $"confmKey={api_key}&currentPage={page}&countPerPage={count_per_page}&keyword={KEYWORD}&resultType=json";
            var response = GetData(_keyword, page);
            if (response == null) { return list; }
            list = response.results.Juso;
            return list;
        }


        private ResponseModel GetData(string keyword, int page = 1)
        {
            ResponseModel result;
            string url = base_url + $"confmKey={api_key}&currentPage={page}&countPerPage={count_per_page}&keyword={keyword}&resultType=json";
            string json;
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(10);

                    var response = client.GetAsync(url).Result;
                    response.EnsureSuccessStatusCode();
                    json = response.Content.ReadAsStringAsync().Result;
                }
                result = JsonConvert.DeserializeObject<ResponseModel>(json);
                _last_response = result;
                // CURRENT_PAGE = page;
                _keyword = keyword;

            }
            catch (Exception ex)
            {
                result = new ResponseModel();
                result.results.common.errorCode = -1;
                result.results.common.errorMessage = ex.Message;
            }
            return result;
        }

    }
}
