using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Finder.Model
{
    public class ResponseModel
    {
        /// <summary>
        /// 검색 결과 (공통 정보 + 주소 리스트)
        /// </summary>
        public Results results { get; set; }
    }

    /// <summary>
    /// 검색 결과 공통 정보
    /// </summary>
    public class Common
    {
        /// <summary>
        /// 전체 검색 결과 수
        /// </summary>
        public int totalCount { get; set; }

        /// <summary>
        /// 현재 페이지 번호
        /// </summary>
        public int currentPage { get; set; }

        /// <summary>
        /// 페이지당 표시 건수
        /// </summary>
        public int countPerPage { get; set; }

        /// <summary>
        /// 오류 코드 (0: 정상)
        /// </summary>
        public int errorCode { get; set; }

        /// <summary>
        /// 오류 메시지
        /// </summary>
        public string errorMessage { get; set; }
    }

    /// <summary>
    /// 결과 데이터
    /// </summary>
    public class Results
    {
        /// <summary>
        /// 공통 정보
        /// </summary>
        public Common common { get; set; }

        /// <summary>
        /// 주소 리스트
        /// </summary>
        public List<juso> Juso { get; set; }
    }
}
