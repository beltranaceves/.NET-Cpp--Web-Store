using System;

namespace Es.Udc.DotNet.PracticaMad.Web.HTTP.Session
{
  public class ClientSession
  {
    private long clientId;
    private String firstName;

    public long ClientId
    {
      get { return clientId; }
      set { clientId = value; }
    }

    public String FirstName
    {
      get { return firstName; }
      set { firstName = value; }
    }
  }
}