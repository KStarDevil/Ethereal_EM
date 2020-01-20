using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

public class OAuthTokenHandler : Microsoft.IdentityModel.Tokens.ISecurityTokenValidator
{
    private int m_MaximumTokenByteSize;
    private double expiretimespan;
    private string key;
    public OAuthTokenHandler(double expiretimespan, string key)
    {
        this.expiretimespan = expiretimespan;
        this.key = key;
     }

    bool ISecurityTokenValidator.CanValidateToken
    {
        get
        {
            // throw new NotImplementedException();
            return true;
        }
    }

    int ISecurityTokenValidator.MaximumTokenSizeInBytes
    {
        get
        {
            return this.m_MaximumTokenByteSize;
        }

        set
        {
            this.m_MaximumTokenByteSize = value;
        }
    }

    bool ISecurityTokenValidator.CanReadToken(string securityToken)
    {
        System.Console.WriteLine(securityToken);
        return true;
    }

    ClaimsPrincipal ISecurityTokenValidator.ValidateToken(string securityToken, TokenValidationParameters validationParameters, out SecurityToken validatedToken)
    {
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

        //try
        //{
            //Default
            //tokenHandler.ValidateToken(securityToken, validationParameters, out validatedToken);
            //validatedToken = new JwtSecurityToken("jwtEncodedString");

            // var clienturl = "";                      
            // clienturl = Request.Headers["myOrigin"];                           
            // //read key from db            
            // var customerdata = (from ev in _objdb.TbGeCustomer     
            //     where ev.Url == clienturl.ToString()                        
            //     select ev).ToList();            
            // key = customerdata[0].EncryptKey;

            //Custom Check For AuthToken 
        //     string tokenData = GlobalESS.Globalfunction.DecryptToken(securityToken, true, this.key);
        //     GlobalESS.TokenData _tokenData = GlobalESS.Globalfunction.GetTokenDataNotUseJWT(tokenData);
        //     double expireTime = this.expiretimespan;

        //     DateTime issueDate = _tokenData.TicketExpireDate.AddMinutes(-expireTime);
        //     DateTime NowDate = System.DateTime.UtcNow;
        //     if (issueDate > NowDate || _tokenData.TicketExpireDate < NowDate)
        //     {
        //         throw new ArgumentException("Token Expire");
        //     }
        // }
        // catch (Exception ex)
        // {
        //     System.Console.WriteLine(ex.Message);
        //     //throw;
        // }

        ClaimsPrincipal principal = null;
        // SecurityToken validToken = null;
        validatedToken = null;


        System.Collections.Generic.List<System.Security.Claims.Claim> ls =
            new System.Collections.Generic.List<System.Security.Claims.Claim>();

        ls.Add(
            new System.Security.Claims.Claim(
                System.Security.Claims.ClaimTypes.Name, "Globalwave"
            , System.Security.Claims.ClaimValueTypes.String
            )
        );

        // 

        System.Security.Claims.ClaimsIdentity id = new System.Security.Claims.ClaimsIdentity("authenticationType");
        id.AddClaims(ls);

        principal = new System.Security.Claims.ClaimsPrincipal(id);

        return principal;
        throw new NotImplementedException();
    }


}