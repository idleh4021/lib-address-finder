# 🏠 Address Finder

**행정안전부**에서 제공하는 **주소검색 Open API**를 활용한  
간편한 **C#용 주소검색 라이브러리**입니다.

WinForm 등 .NET 기반 프로젝트에서 간단하게 주소 검색 기능을 구현할 수 있습니다.

---

## 🔧 특징

- 행안부 주소검색 API(`https://business.juso.go.kr/`) 기반
- 간단한 호출로 도로명/지번 주소 검색
- 페이지 이동 지원

---

## 📦 설치 및 준비

1. **API Key 발급**
   - [행안부 주소검색 API 페이지](https://business.juso.go.kr/addrlink/openApi/apiReqst.do) 접속  
   - 회원가입 후 **검색용 API Key** 발급받기

2. **라이브러리 추가**
   - `Address_Finder.dll`을 프로젝트에 참조 추가  
     (또는 NuGet 배포 시 `Install-Package Address_Finder` 형태로 설치 예정)

3. **필수 패키지**: Newtonsoft.Json (JSON 파싱용)
   ```powershell
   Install-Package Newtonsoft.Json
---


## 🔧 주요 기능

| 기능 | 설명 | 관련 메서드 / 코드 예시 |
|------|------|-------------------------|
| 🔍 **주소 검색** | 키워드(도로명, 지번 등)를 이용해 주소를 검색합니다. | `var list = finder.GetAddress("서울시 강남구");` |
| 📑 **페이지 이동** | 검색 결과가 여러 페이지일 경우, 페이지 간 이동을 지원합니다. | `finder.MovePage(2);` |
| 🧭 **검색 결과 바인딩** | 검색 결과(`List<juso>`)를 DataGridView 등에 바로 표시할 수 있습니다. | `dataGridView1.DataSource = list;` |
| 🏷️ **선택된 주소 반환** | DataGridView 등에서 선택한 주소를 모델로 가져옵니다. | `juso sel = (juso)dataGridView1.CurrentRow.DataBoundItem;` |
| ⚙️ **간단한 초기화** | API Key만 등록하면 바로 사용 가능합니다. | `var finder = new Address_Finder.Address_Finder("your_api_key");` |


> ⚡ **자세한 사용 방법과 UI 예제는 [`example_core`](./example_core) 프로젝트를 참고하세요.**

---

## 📄 반환 모델 (`juso`)

| 필드명 | 설명 |
|--------|------|
| `roadAddr` | 도로명 주소 |
| `jibunAddr` | 지번 주소 |
| `zipNo` | 우편번호 |
| `admCd` | 행정구역 코드 |
| `rnMgtSn` | 도로명 관리번호 |
| `bdMgtSn` | 건물관리번호 |
...

---

## ⚙️ 기본 사용 흐름

```csharp
var finder = new Address_Finder.Address_Finder("your_api_key");
var result = finder.GetAddress("서울시 강남구");
dataGridView1.DataSource = result;