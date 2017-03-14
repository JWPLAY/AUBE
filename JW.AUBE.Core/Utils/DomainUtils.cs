using System.Data;
using System.Windows.Forms;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Core.Resources;

namespace JW.AUBE.Core.Utils
{
	public static class DomainUtils
	{
		public static void SetData()
		{
			try
			{
				var dtDictionaries = ServerRequest.SingleRequest("Auth", "GetDictionaries", "Dictionaries", new DataMap() { });
				if (dtDictionaries != null && (dtDictionaries as DataTable).Rows.Count > 0)
				{
					foreach (DataRow dr in (dtDictionaries as DataTable).Rows)
					{
						DomainResource.Fields.SetValue(dr["NAME"].ToString(), dr["VALUE"].ToString());
					}
				}

				var dtMessages = ServerRequest.SingleRequest("Auth", "GetMessages", "Messages", new DataMap() { });
				if (dtMessages != null && (dtMessages as DataTable).Rows.Count > 0)
				{
					foreach (DataRow dr in (dtMessages as DataTable).Rows)
					{
						DomainResource.Messages.SetValue(dr["NAME"].ToString(), dr["VALUE"].ToString());
					}
				}
			}
			catch
			{
				throw;
			}
		}



		public static string GetFieldName(string key)
		{
			var ucaseName = StringUtils.ToUpperUnderscoreByPattern(key).Trim();
			var ret = DomainResource.Fields.GetValue(ucaseName);
			if (string.IsNullOrEmpty(ret))
			{
				var keys = ucaseName.Split('_');
				foreach (string k in keys)
				{
					var caseName = DomainResource.Fields.GetValue(k);
					if (!string.IsNullOrEmpty(caseName))
					{
						ret += caseName;
					}
				}
			}
			if (string.IsNullOrEmpty(ret))
			{
				ret = ucaseName.Replace("_", " ");
			}
			return ret;
		}

		public static void SetFieldName(string key, string value)
		{
			DomainResource.Fields.SetValue(key, value);
		}

		public static string GetMessageValue(string key)
		{
			var ret = DomainResource.Messages.GetValue(key);
			if (string.IsNullOrEmpty(ret))
			{
				ret = key;
			}
			return ret;
		}

		public static void SetMessageValue(string key, string value)
		{
			DomainResource.Messages.SetValue(key, value);
		}

		public static string GetPopMenuValue(string key)
		{
			var ret = DomainResource.PopMenus.GetValue(key);
			if (string.IsNullOrEmpty(ret))
			{
				ret = key;
			}
			return ret;
		}

		public static void SetPopMenuValue(string key, string value)
		{
			DomainResource.PopMenus.SetValue(key, value);
		}

		public static void Init()
		{
			InitMessages();
			InitPopMenus();
		}

		private static void InitMessages()
		{
			DomainResource.Messages.Add("SYSTEM_CLOSE", string.Format("{0} 시스템을 종료하겠습니까?", Application.ProductName));
		}
		private static void InitPopMenus()
		{
			DomainResource.PopMenus.Add("CustomizationBands", "밴드");
			DomainResource.PopMenus.Add("CustomizationCaption", "사용자정의 컬럼(밴드) 구성");
			DomainResource.PopMenus.Add("CustomizationColumns", "컬럼");

			DomainResource.PopMenus.Add("GridGroupPanelText", "그룹패널");

			DomainResource.PopMenus.Add("FilterBuilderApplyButton", "적용");
			DomainResource.PopMenus.Add("FilterBuilderCancelButton", "취소");
			DomainResource.PopMenus.Add("FilterBuilderCaption", "필터작성기");
			DomainResource.PopMenus.Add("FilterBuilderOkButton", "확인");
			DomainResource.PopMenus.Add("FindControlClearButton", "지우기");
			DomainResource.PopMenus.Add("FindControlFindButton", "찾기");

			DomainResource.PopMenus.Add("MenuBandFrameLeftFix", "그룹 좌측에 틀 고정");
			DomainResource.PopMenus.Add("MenuBandFrameRightFix", "그룹 우측에 틀 고정");
			DomainResource.PopMenus.Add("MenuBandLeftFix", "그룹 좌측에 열 고정");
			DomainResource.PopMenus.Add("MenuBandRightFix", "그룹 우측에 열 고정");
			DomainResource.PopMenus.Add("MenuBandsUnFix", "모든 열 그룹 고정 해제");
			DomainResource.PopMenus.Add("MenuBandUnFix", "선택 열 그룹 고정 해제");

			DomainResource.PopMenus.Add("MenuCellMerge", "셀병합");
			DomainResource.PopMenus.Add("MenuColumnAutoFilterRowHide", "자동 필터행 숨기기");
			DomainResource.PopMenus.Add("MenuColumnAutoFilterRowShow", "자동 필터행 보이기");
			DomainResource.PopMenus.Add("MenuColumnAverageSummaryTypeDescription", "평균합계 유형설명");
			DomainResource.PopMenus.Add("MenuColumnBandCustomization", "사용자정의 밴드구성");
			DomainResource.PopMenus.Add("MenuColumnBestFit", "컬럼길이 자동조정");
			DomainResource.PopMenus.Add("MenuColumnBestFitAllColumns", "컬럼길이 자동조정 (전체)");
			DomainResource.PopMenus.Add("MenuColumnClearFilter", "필터 해제");
			DomainResource.PopMenus.Add("MenuColumnClearSorting", "정렬 해제");
			DomainResource.PopMenus.Add("MenuColumnColumnCustomization", "사용자정의 컬럼구성");
			DomainResource.PopMenus.Add("MenuColumnCountSummaryTypeDescription", "개수합계 유형설명");
			DomainResource.PopMenus.Add("MenuColumnExpressionEditor", "표현식 작성기");
			DomainResource.PopMenus.Add("MenuColumnFilter", "필터");
			DomainResource.PopMenus.Add("MenuColumnFilterEditor", "필터 작성기");
			DomainResource.PopMenus.Add("MenuColumnFilterMode", "컬럼필터모드");
			DomainResource.PopMenus.Add("MenuColumnFilterModeDisplayText", "컬럼필터표시값");
			DomainResource.PopMenus.Add("MenuColumnFilterModeValue", "컬럼필터값");
			DomainResource.PopMenus.Add("MenuColumnFindFilterHide", "검색필터(결과내 검색) 숨기기");
			DomainResource.PopMenus.Add("MenuColumnFindFilterShow", "검색필터(결과내 검색) 보이기");
			DomainResource.PopMenus.Add("MenuColumnFrameLeftFix", "좌측에 틀 고정");
			DomainResource.PopMenus.Add("MenuColumnFrameRightFix", "우측에 틀 고정");
			DomainResource.PopMenus.Add("MenuColumnGroup", "선택한 컬럼만 그룹화");
			DomainResource.PopMenus.Add("MenuColumnGroupBox", "그룹박스");
			DomainResource.PopMenus.Add("MenuColumnGroupIntervalDay", "그룹 간격 (일)");
			DomainResource.PopMenus.Add("MenuColumnGroupIntervalMenu", "그룹 간격 (메뉴)");
			DomainResource.PopMenus.Add("MenuColumnGroupIntervalMonth", "그룹 간격 (월)");
			DomainResource.PopMenus.Add("MenuColumnGroupIntervalNone", "그룹 간격 (없음)");
			DomainResource.PopMenus.Add("MenuColumnGroupIntervalSmart", "그룹 간격 (스마트)");
			DomainResource.PopMenus.Add("MenuColumnGroupIntervalYear", "그룹 간격 (년)");
			DomainResource.PopMenus.Add("MenuColumnGroupSummaryEditor", "그룹합계 작성기");
			DomainResource.PopMenus.Add("MenuColumnGroupSummarySortFormat", "그룹합계 정렬형식");
			DomainResource.PopMenus.Add("MenuColumnLeftFix", "좌측에 열 고정");
			DomainResource.PopMenus.Add("MenuColumnMaxSummaryTypeDescription", "최대합계 유형설명");
			DomainResource.PopMenus.Add("MenuColumnMinSummaryTypeDescription", "최소합계 유형설명");
			DomainResource.PopMenus.Add("MenuColumnRemoveColumn", "컬럼 숨기기");
			DomainResource.PopMenus.Add("MenuColumnResetGroupSummarySort", "그룹합계 정렬해제");
			DomainResource.PopMenus.Add("MenuColumnRightFix", "우측에 열 고정");
			DomainResource.PopMenus.Add("MenuColumnShowColumn", "컬럼 보이기");
			DomainResource.PopMenus.Add("MenuColumnSortAscending", "정렬 (오름차순)");
			DomainResource.PopMenus.Add("MenuColumnSortDescending", "정렬 (내림차순)");
			DomainResource.PopMenus.Add("MenuColumnSortGroupBySummaryMenu", "정렬 (그룹합계)");
			DomainResource.PopMenus.Add("MenuColumnSumSummaryTypeDescription", "부분합계 유형설명");
			DomainResource.PopMenus.Add("MenuColumnsUnFix", "모든 열 고정 해제");
			DomainResource.PopMenus.Add("MenuColumnUnFix", "선택 열 고정 해제");
			DomainResource.PopMenus.Add("MenuColumnUnGroup", "그룹해제");

			DomainResource.PopMenus.Add("MenuCopyCell", "셀값 복사");
			DomainResource.PopMenus.Add("MenuDeleteLayout", "그리드 레이아웃 정보 삭제");
			DomainResource.PopMenus.Add("MenuExportExcel", "엑셀 내보내기");

			DomainResource.PopMenus.Add("MenuFooterAverage", "Footer 평균");
			DomainResource.PopMenus.Add("MenuFooterAverageFormat", "Footer 평균형식");
			DomainResource.PopMenus.Add("MenuFooterCount", "Footer 건수");
			DomainResource.PopMenus.Add("MenuFooterCountFormat", "Footer 건수형식");
			DomainResource.PopMenus.Add("MenuFooterCountGroupFormat", "Footer 그룹형식");
			DomainResource.PopMenus.Add("MenuFooterCustomFormat", "Footer 사용자 정의 형식");
			DomainResource.PopMenus.Add("MenuFooterMax", "Footer 최대값");
			DomainResource.PopMenus.Add("MenuFooterMaxFormat", "Footer 최대값 형식");
			DomainResource.PopMenus.Add("MenuFooterMin", "Footer 최소값");
			DomainResource.PopMenus.Add("MenuFooterMinFormat", "Footer 최소값 형식");
			DomainResource.PopMenus.Add("MenuFooterNone", "Footer 없음");
			DomainResource.PopMenus.Add("MenuFooterSum", "Footer 합계");
			DomainResource.PopMenus.Add("MenuFooterSumFormat", "Footer 합계형식");

			DomainResource.PopMenus.Add("MenuGroupPanelClearGrouping", "그룹패널 정리");
			DomainResource.PopMenus.Add("MenuGroupPanelFullCollapse", "그룹패널 모두 접기");
			DomainResource.PopMenus.Add("MenuGroupPanelFullExpand", "그룹패널 모두 펼치기");
			DomainResource.PopMenus.Add("MenuGroupPanelHide", "그룹패널 숨기기");
			DomainResource.PopMenus.Add("MenuGroupPanelShow", "그룹패널 보이기");

			DomainResource.PopMenus.Add("MenuSaveLayout", "그리드 레이아웃 정보 저장");
			DomainResource.PopMenus.Add("MenuShowFindPanel", "결과내 검색");

			DomainResource.PopMenus.Add("NavigatorTextStringFormat", "Page { 0} of { 1}");
			DomainResource.PopMenus.Add("PictureEditMenuCopy", "복사");
			DomainResource.PopMenus.Add("PictureEditMenuCut", "잘라내기");
			DomainResource.PopMenus.Add("PictureEditMenuDelete", "삭제");
			DomainResource.PopMenus.Add("PictureEditMenuLoad", "불러오기");
			DomainResource.PopMenus.Add("PictureEditMenuPaste", "붙여넣기");
			DomainResource.PopMenus.Add("PictureEditMenuSave", "저장");

			DomainResource.PopMenus.Add("MenuCheckAll", "전체선택");
			DomainResource.PopMenus.Add("MenuUnCheckAll", "전체선택해제");
		}
	}
}
