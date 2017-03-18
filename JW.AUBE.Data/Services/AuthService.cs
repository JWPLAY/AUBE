using System;
using System.Collections.Generic;
using System.Data;
using JW.AUBE.Base.Map;
using JW.AUBE.Base.Utils;
using JW.AUBE.Base.Was.Models;
using JW.AUBE.Service.Mappers;
using JW.AUBE.Model.Base;

namespace JW.AUBE.Service.Services
{
	public static class AuthService
	{
		/// <summary>
		/// CheckLoginUser
		/// 로그인 체크
		/// </summary>
		/// <param name="req">WasRequest</param>
		/// <returns>WasRequest</returns>
		public static WasRequest CheckLoginUser(WasRequest req)
		{
			try
			{
				req.Parameter.SetValue("USER_ID", null);
				var loginUser = DaoFactory.Instance.QueryForObject<LoginUserData>("GetLoginUser", req.Parameter);

				if (loginUser == null)
				{
					req.ErrorNumber = -1;
					req.ErrorMessage = "해당 아이디로 사용자를 찾을 수 없습니다.";
					return req;
				}

				if (loginUser.UseYn != "Y")
				{
					req.ErrorNumber = -2;
					req.ErrorMessage = "사용 가능한 아이디가 아닙니다. 확인 후 다시 시도하세요!!!";
					return req;
				}

				if (loginUser.Password != req.Parameter.GetValue("Password").ToStringNullToEmpty())
				{
					req.ErrorNumber = -3;
					req.ErrorMessage = "비밀번호가 정확하지 않습니다. 확인 후 다시 시도하세요!!!";
					return req;
				}

				req.Parameter.SetValue("USER_ID", loginUser.UserId);

				try
				{
					DaoFactory.Instance.Insert("InsertLoginLog", req.Parameter);
				}
				catch (Exception ex)
				{
					throw new Exception("로그인로그 저장 중 오류가 발생하였습니다.\r\n" + ErrorUtils.GetMessage(ex));
				}

				DataTable dt = new DataTable();
				dt.Columns.AddRange(new DataColumn[]
				{
					new DataColumn("USER_ID", typeof(string)),
					new DataColumn("USER_NAME", typeof(string))
				});
				dt.Rows.Add(loginUser.UserId, loginUser.UserName);

				req.DataList = new List<WasRequestData>()
				{
					new WasRequestData()
					{
						 Schema = new SchemaMap()
						 {
							 { "USER_ID", typeof(string) },
							 { "USER_NAME", typeof(string) }
						 }
						 ,
						 Data = dt
					}
				};

				return req;
			}
			catch (Exception ex)
			{
				req.ErrorNumber = ex.HResult;
				req.ErrorMessage = ex.Message;
				return req;
			}
		}

		/// <summary>
		/// Logout
		/// 로그아웃
		/// </summary>
		/// <param name="req">WasRequest</param>
		/// <returns>WasRequest</returns>
		public static WasRequest Logout(WasRequest req)
		{
			try
			{
				try
				{
					DaoFactory.Instance.Update("UpdateLogout", req.Parameter);
				}
				catch (Exception ex)
				{
					throw new Exception("로그아웃 정보 저장 중 오류가 발생하였습니다.\r\n" + ErrorUtils.GetMessage(ex));
				}
				return req;
			}
			catch (Exception ex)
			{
				req.ErrorNumber = ex.HResult;
				req.ErrorMessage = ex.Message;
				return req;
			}
		}

		/// <summary>
		/// GetUserMenus
		/// 사용자별 메뉴구성
		/// </summary>
		/// <param name="req">WasRequest</param>
		/// <returns>WasRequest</returns>
		public static WasRequest GetMainMenus(WasRequest req)
		{
			try
			{
				var list = DaoFactory.Instance.QueryForList<DataMap>("GetMainMenus", req.Parameter);
				req.DataList = new List<WasRequestData>()
				{
					new WasRequestData()
					{
						Data = ConvertUtils.DataMapListToDataTable(list, req.SqlId)
					}
				};
				return req;
			}
			catch (Exception ex)
			{
				req.ErrorNumber = ex.HResult;
				req.ErrorMessage = ex.Message;
				return req;
			}
		}

		/// <summary>
		/// GetFormData
		/// 화면정보 가져오기
		/// </summary>
		/// <param name="req">WasRequest</param>
		/// <returns>WasRequest</returns>
		public static WasRequest GetFormData(WasRequest req)
		{
			try
			{
				var data = DaoFactory.Instance.QueryForObject<DataMap>("GetViewData", req.Parameter);
				List<DataMap> list = new List<DataMap>();
				if (data != null)
				{
					list.Add(data);
				}
				req.DataList = new List<WasRequestData>()
				{
					new WasRequestData()
					{
						Data = ConvertUtils.DataMapListToDataTable(list, "GetFormData")
					}
				};
				return req;
			}
			catch (Exception ex)
			{
				req.ErrorNumber = ex.HResult;
				req.ErrorMessage = ex.Message;
				return req;
			}
		}

		/// <summary>
		/// SaveBookmark
		/// 북마크 저장
		/// </summary>
		/// <param name="req">WasRequest</param>
		/// <returns>WasRequest</returns>
		public static WasRequest SaveBookmark(WasRequest req)
		{
			try
			{
				var map = DaoFactory.Instance.QueryForObject<DataMap>("SelectBookmark", req.Parameter);
				if (map == null || map.GetValue("user_id") == null)
				{
					DaoFactory.Instance.Insert("InsertBookmark", req.Parameter);
				}
				return req;
			}
			catch (Exception ex)
			{
				req.ErrorNumber = ex.HResult;
				req.ErrorMessage = ex.Message;
				return req;
			}
		}

		/// <summary>
		/// GetDomains
		/// 도메인 가져오기
		/// </summary>
		/// <param name="req">WasRequest</param>
		/// <returns>WasRequest</returns>
		public static WasRequest GetDictionaries(WasRequest req)
		{
			try
			{
				IList<DataMap> list = DaoFactory.Instance.QueryForList<DataMap>("GetDictionaries", req.Parameter);
				req.DataList = new List<WasRequestData>()
				{
					new WasRequestData()
					{
						Data = ConvertUtils.DataMapListToDataTable(list, req.SqlId)
					}
				};
				return req;
			}
			catch (Exception ex)
			{
				req.ErrorNumber = ex.HResult;
				req.ErrorMessage = ex.Message;
				return req;
			}
		}

		public static WasRequest GetMessages(WasRequest req)
		{
			try
			{
				IList<DataMap> list = DaoFactory.Instance.QueryForList<DataMap>("GetMessages", req.Parameter);
				req.DataList = new List<WasRequestData>()
				{
					new WasRequestData()
					{
						Data = ConvertUtils.DataMapListToDataTable(list, req.SqlId)
					}
				};
				return req;
			}
			catch (Exception ex)
			{
				req.ErrorNumber = ex.HResult;
				req.ErrorMessage = ex.Message;
				return req;
			}
		}

		/// <summary>
		/// GetSettings
		/// 시스템설정 가져오기
		/// </summary>
		/// <param name="req">WasRequest</param>
		/// <returns>WasRequest</returns>
		public static WasRequest GetSettings(WasRequest req)
		{
			try
			{
				var list = DaoFactory.Instance.QueryForList<DataMap>("GetSettings", req.Parameter);
				req.DataList = new List<WasRequestData>()
				{
					new WasRequestData()
					{
						Data = ConvertUtils.DataMapListToDataTable(list, req.SqlId)
					}
				};
				return req;
			}
			catch (Exception ex)
			{
				req.ErrorNumber = ex.HResult;
				req.ErrorMessage = ex.Message;
				return req;
			}
		}

		/// <summary>
		/// GetHelpContent
		/// 도움말 컨텐츠
		/// </summary>
		/// <param name="req">WasRequest</param>
		/// <returns>WasRequest</returns>
		public static WasRequest GetHelpContent(WasRequest req)
		{
			try
			{
				var data = DaoFactory.Instance.QueryForObject<DataMap>("GetHelpContent", req.Parameter);
				List<DataMap> list = new List<DataMap>();
				if (data != null)
					list.Add(data);

				req.DataList = new List<WasRequestData>()
				{
					new WasRequestData()
					{
						Data = ConvertUtils.DataMapListToDataTable(list, req.SqlId)
					}
				};
				return req;
			}
			catch (Exception ex)
			{
				req.ErrorNumber = ex.HResult;
				req.ErrorMessage = ex.Message;
				return req;
			}
		}

		/// <summary>
		/// GetStyles
		/// 스타일 정보
		/// </summary>
		/// <param name="req">WasRequest</param>
		/// <returns>WasRequest</returns>
		public static WasRequest GetStyles(WasRequest req)
		{
			try
			{
				var list = DaoFactory.Instance.QueryForList<DataMap>("GetStyles", req.Parameter);
				req.DataList = new List<WasRequestData>()
				{
					new WasRequestData()
					{
						Data = ConvertUtils.DataMapListToDataTable(list, req.SqlId)
					}
				};
				return req;
			}
			catch (Exception ex)
			{
				req.ErrorNumber = ex.HResult;
				req.ErrorMessage = ex.Message;
				return req;
			}
		}
	}
}
