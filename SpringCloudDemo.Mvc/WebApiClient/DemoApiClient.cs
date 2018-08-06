
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;
using Swagger2WebApiClient.Infrastructure;
using Swagger2WebApiClient.Models;
using UOKO.Demo.Models;
using UOKO.Demo.Api;
using Refit;
#region Models
namespace UOKO.Demo.Models
{
	/// <summary>
	/// 
	/// </summary>
	public class UserInfoViewModel  
	{
		
		public string Email { get; set; }
				
		public bool HasRegistered { get; set; }
				
		public string LoginProvider { get; set; }
				
		    }
	/// <summary>
	/// 
	/// </summary>
	public class ManageInfoViewModel  
	{
		
		public string LocalLoginProvider { get; set; }
				
		public string Email { get; set; }
				
		public List<UserLoginInfoViewModel> Logins { get; set; }
				
		public List<ExternalLoginViewModel> ExternalLoginProviders { get; set; }
				
		    }
	/// <summary>
	/// 
	/// </summary>
	public class UserLoginInfoViewModel  
	{
		
		public string LoginProvider { get; set; }
				
		public string ProviderKey { get; set; }
				
		    }
	/// <summary>
	/// 
	/// </summary>
	public class ExternalLoginViewModel  
	{
		
		public string Name { get; set; }
				
		public string Url { get; set; }
				
		public string State { get; set; }
				
		    }
	/// <summary>
	/// 
	/// </summary>
	public class ChangePasswordBindingModel  
	{
		
		public string OldPassword { get; set; }
				
		public string NewPassword { get; set; }
				
		public string ConfirmPassword { get; set; }
				
		    }
	/// <summary>
	/// 
	/// </summary>
	public class SetPasswordBindingModel  
	{
		
		public string NewPassword { get; set; }
				
		public string ConfirmPassword { get; set; }
				
		    }
	/// <summary>
	/// 
	/// </summary>
	public class AddExternalLoginBindingModel  
	{
		
		public string ExternalAccessToken { get; set; }
				
		    }
	/// <summary>
	/// 
	/// </summary>
	public class RemoveLoginBindingModel  
	{
		
		public string LoginProvider { get; set; }
				
		public string ProviderKey { get; set; }
				
		    }
	/// <summary>
	/// 
	/// </summary>
	public class RegisterBindingModel  
	{
		
		public string Email { get; set; }
				
		public string Password { get; set; }
				
		public string ConfirmPassword { get; set; }
				
		    }
	/// <summary>
	/// 
	/// </summary>
	public class RegisterExternalBindingModel  
	{
		
		public string Email { get; set; }
				
		    }
	/// <summary>
	/// 
	/// </summary>
	public class User  
	{
		
		public int Id { get; set; }
				
		public string Name { get; set; }
				
		public int Gender { get; set; }
				
		public int Age { get; set; }
				
		public Address Address { get; set; }
				
		    }
	/// <summary>
	/// 
	/// </summary>
	public class Address  
	{
		
		public string Province { get; set; }
				
		    }

}

#endregion

#region ApiClient
namespace UOKO.Demo.Api{

	/// <summary>
	/// Web Api Client For Account
	/// </summary>
	public interface IAccountWebApi
	{
		/// <summary>
    /// 
    /// </summary>
	    /// <returns></returns>
	[Get("/api/Account/UserInfo")]
	Task<UserInfoViewModel>  GetUserInfoAsync();

		/// <summary>
    /// 
    /// </summary>
	    /// <returns></returns>
	[Post("/api/Account/Logout")]
	Task  LogoutAsync();

		/// <summary>
    /// 
    /// </summary>
	    /// <param name="returnUrl"></param>
	    /// <param name="generateState"></param>
	    /// <returns></returns>
	[Get("/api/Account/ManageInfo")]
	Task<ManageInfoViewModel>  GetManageInfoAsync(string returnUrl, bool? generateState = null);

		/// <summary>
    /// 
    /// </summary>
	    /// <param name="model"></param>
	    /// <returns></returns>
	[Post("/api/Account/ChangePassword")]
	Task  ChangePasswordAsync([Body] ChangePasswordBindingModel model);

		/// <summary>
    /// 
    /// </summary>
	    /// <param name="model"></param>
	    /// <returns></returns>
	[Post("/api/Account/SetPassword")]
	Task  SetPasswordAsync([Body] SetPasswordBindingModel model);

		/// <summary>
    /// 
    /// </summary>
	    /// <param name="model"></param>
	    /// <returns></returns>
	[Post("/api/Account/AddExternalLogin")]
	Task  AddExternalLoginAsync([Body] AddExternalLoginBindingModel model);

		/// <summary>
    /// 
    /// </summary>
	    /// <param name="model"></param>
	    /// <returns></returns>
	[Post("/api/Account/RemoveLogin")]
	Task  RemoveLoginAsync([Body] RemoveLoginBindingModel model);

		/// <summary>
    /// 
    /// </summary>
	    /// <param name="provider"></param>
	    /// <param name="error"></param>
	    /// <returns></returns>
	[Get("/api/Account/ExternalLogin")]
	Task  GetExternalLoginAsync(string provider, string error = null);

		/// <summary>
    /// 
    /// </summary>
	    /// <param name="returnUrl"></param>
	    /// <param name="generateState"></param>
	    /// <returns></returns>
	[Get("/api/Account/ExternalLogins")]
	Task<List<ExternalLoginViewModel>>  GetExternalLoginsAsync(string returnUrl, bool? generateState = null);

		/// <summary>
    /// 
    /// </summary>
	    /// <param name="model"></param>
	    /// <returns></returns>
	[Post("/api/Account/Register")]
	Task  RegisterAsync([Body] RegisterBindingModel model);

		/// <summary>
    /// 
    /// </summary>
	    /// <param name="model"></param>
	    /// <returns></returns>
	[Post("/api/Account/RegisterExternal")]
	Task  RegisterExternalAsync([Body] RegisterExternalBindingModel model);

	}
	/// <summary>
	/// Web Api Client For User
	/// </summary>
	public interface IUserWebApi
	{
		/// <summary>
    /// 
    /// </summary>
	    /// <returns></returns>
	[Get("/api/user")]
	Task<List<User>>  GetAllAsync();

		/// <summary>
    /// 
    /// </summary>
	    /// <param name="id"></param>
	    /// <returns></returns>
	[Get("/api/user/{id}")]
	Task<User>  GetAsync(int? id);

	}

}
#endregion

