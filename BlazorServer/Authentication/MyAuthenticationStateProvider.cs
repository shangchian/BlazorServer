using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;

namespace BlazorServer.Authentication {
  public class MyAuthenticationStateProvider : AuthenticationStateProvider {

    private readonly ProtectedSessionStorage pss;
    private ClaimsPrincipal anonymous = new( new ClaimsIdentity( ) );

    public MyAuthenticationStateProvider( ProtectedSessionStorage pss ) {
      this.pss = pss;
    }
    public override async Task<AuthenticationState> GetAuthenticationStateAsync( ) {
      try {
        var result = await pss.GetAsync<LoginUserInfo>( "LoginUserInfo" );
        LoginUserInfo? userInfo = null;
        if ( result.Success ) {
          userInfo = result.Value;
        }
        if ( userInfo is null ) {
          return await Task.FromResult( new AuthenticationState( anonymous ) );
        }
        ClaimsIdentity identity = new( new List<Claim> {
                new Claim(ClaimTypes.Name, userInfo.UserName),
                new Claim(ClaimTypes.Role, userInfo.Role),
          } , "CustomAuthentication" );

        ClaimsPrincipal principal = new( identity );
        return await Task.FromResult( new AuthenticationState( principal ) );
      }
      catch {
        return await Task.FromResult( new AuthenticationState( anonymous ) );
      }
    }

    public async Task UpdateState( LoginUserInfo userInfo ) {
      ClaimsPrincipal principal;
      if ( userInfo is null ) {
        await pss.DeleteAsync( "LoginUserInfo" );
        principal = anonymous;
      }
      else {
        await pss.SetAsync( "LoginUserInfo" , userInfo );
        ClaimsIdentity identity = new( new List<Claim> {
          new Claim(ClaimTypes.Name, userInfo.UserName),
          new Claim(ClaimTypes.Role, userInfo.Role),
        } , "CustomAuthentication" );
        principal = new ClaimsPrincipal( identity );
      }
      NotifyAuthenticationStateChanged(
        Task.FromResult( new AuthenticationState( principal ) ) );
    }
  }

}
