namespace RealEstate_Dapper_Api.Tools
{
    public class TokenResposeViewModel
    {
        public TokenResposeViewModel(string token, DateTime expireDate)
        {
            Token = token;
            ExpireDate = expireDate;
        }

        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
