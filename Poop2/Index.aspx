<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BrendonEksamen.Index" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
      <title></title>
   </head>
   <body>
      <form id="form1" runat="server">
         <div>
            <div class="jumbotron">
               <h1>Elev og Skole nettside</h1>
               <p class="lead">En liten nettside som lar deg søke etter individuelle elever, klasser og fag med SQL statementer.</p>
            </div>
            <div class="row">
               <div class="col-md-4">
                  <h2>Søk etter individuell elev</h2>
                  <p>Fornavn</p>
                  <asp:TextBox ID="TextBoxByElev" runat="server"></asp:TextBox>
                  <asp:Button ID="ButtonSearchByElev" runat="server" Text="Søk" OnClick="ButtonSearchByElev_Click" />
                  <asp:GridView ID="GridViewByElev" runat="server">
                  </asp:GridView>
               </div>
               <div class="col-md-4">
                  <h2>Alle elever i fag</h2>
                  <p>Fag</p>
                  <asp:TextBox ID="TextBoxByFag" runat="server"></asp:TextBox>
                  <asp:Button ID="ButtonSearchByFag" runat="server" Text="Søk" OnClick="ButtonSearchByFag_Click" />
                  <asp:GridView ID="GridViewByFag" runat="server">
                  </asp:GridView>
               </div>
               <div class="col-md-4">
                  <h2>Alle elever i klasse</h2>
                  <p>Klasse</p>
                  <asp:TextBox ID="TextBoxByKlasse" runat="server"></asp:TextBox>
                  <asp:Button ID="ButtonSearchByKlasse" runat="server" Text="Søk" OnClick="ButtonSearchByKlasse_Click" />
                  <asp:GridView ID="GridViewByKlasse" runat="server">
                  </asp:GridView>
               </div>
               <div class="col-md-4">
                  <h2>Alle elever etter klasse og fag</h2>
                  <p>Klasse</p>
                  <asp:TextBox ID="TextBoxByKlasseNavn" runat="server"></asp:TextBox>
                  <p>Fag</p>
                  <asp:TextBox ID="TextBoxByFagNavn" runat="server"></asp:TextBox>
                  <br/>
                  <asp:Button ID="ButtonSearchByKlasseofFag" runat="server" Text="Søk" OnClick="ButtonSearchByKlasseogFag_Click" />
                  <asp:GridView ID="GridViewByKlasseogFag" runat="server">
                  </asp:GridView>
               </div>
            </div>
         </div>
      </form>
   </body>
</html>
