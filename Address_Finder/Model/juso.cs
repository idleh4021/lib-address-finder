using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Finder.Model
{
    public class juso
    {
        /// <summary>
        /// 전체 도로명주소
        /// </summary>
        public string roadAddr { get; set; }

        /// <summary>
        /// 도로명주소(참고항목 제외)
        /// </summary>
        public string roadAddrPart1 { get; set; }

        /// <summary>
        /// 도로명주소 참고항목
        /// </summary>
        public string roadAddrPart2 { get; set; }

        /// <summary>
        /// 지번주소
        /// </summary>
        public string jibunAddr { get; set; }

        /// <summary>
        /// 영문 도로명주소
        /// </summary>
        public string engAddr { get; set; }

        /// <summary>
        /// 우편번호
        /// </summary>
        public string zipNo { get; set; }

        /// <summary>
        /// 행정구역코드
        /// </summary>
        public string admCd { get; set; }

        /// <summary>
        /// 도로명 코드
        /// </summary>
        public string rnMgtSn { get; set; }

        /// <summary>
        /// 건물관리번호
        /// </summary>
        public string bdMgtSn { get; set; }

        /// <summary>
        /// 시도명
        /// </summary>
        public string siNm { get; set; }

        /// <summary>
        /// 시군구명
        /// </summary>
        public string sggNm { get; set; }

        /// <summary>
        /// 읍면동명
        /// </summary>
        public string emdNm { get; set; }

        /// <summary>
        /// 법정리명
        /// </summary>
        public string liNm { get; set; }

        /// <summary>
        /// 도로명
        /// </summary>
        public string rn { get; set; }

        /// <summary>
        /// 건물본번
        /// </summary>
        public string buldMnnm { get; set; }

        /// <summary>
        /// 건물부번
        /// </summary>
        public string buldSlno { get; set; }

        /// <summary>
        /// 건물명
        /// </summary>
        public string bdNm { get; set; }

        /// <summary>
        /// 공동주택여부(Y/N)
        /// </summary>
        public string detBdNmList { get; set; }

        /// <summary>
        /// 산 여부 (0:대지, 1:산)
        /// </summary>
        public string mtYn { get; set; }

        /// <summary>
        /// 지번본번(번지)
        /// </summary>
        public string lnbrMnnm { get; set; }

        /// <summary>
        /// 지번부번(호)
        /// </summary>
        public string lnbrSlno { get; set; }

        /// <summary>
        /// 읍면 여부 (0:읍면 아님, 1:읍면)
        /// </summary>
        public string emdNo { get; set; }
    }
}
