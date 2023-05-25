<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatientList.aspx.cs" Inherits="HospitalWebApp.PatientList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Patient List</title>
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="https://getbootstrap.com/docs/5.3/assets/css/docs.css" rel="stylesheet"/>
    <style>
        /* body{
            background-color: #080710;
         }
        .background{
            width: 430px;
            height: 520px;
            position: absolute;
            transform: translate(-50%,-50%);
            left: 50%;
            top: 50%;
         }*/
       
    </style>
</head>
<body style="background-color:#8cff9e;">
    <center><img src = "HealthCare.png" width = "25%" height = "25%"></center>
    <form id="form1" runat="server">
        <div>
            <hr />
            <label for="exampleFormControlInput1" id="Username" runat="server" class="form-label" style="margin-left:75%;margin-right:5px; text-decoration: underline; font-size:20px; "></label>
            <button type="button" id="logout_btn" class="btn btn-secondary" runat="server" onserverclick="logout_btn_ServerClick">Log out</button>             
            <br />
            <div class="row">
                <div class="col-4"></div>
                <div class="col-4">
                    <button type="button" id="add_btn" class="btn btn-primary" runat="server" onserverclick="add_btn_ServerClick">Pasiyent əlavə et</button>
                    <button type="button" id="refresh" class="btn btn-info" runat="server" onserverclick="refresh_ServerClick">Yenilə</button> 
                    <button type="button" id="search_btn" class="btn btn-info" runat="server" onserverclick="search_btn_ServerClick">Pasiyent axtar</button> 
                    
                </div>
                <div class="col-4">
                </div>
            </div>
            <table class="table">
  <thead>
    <tr>
      <th scope="col">id</th>
      <th scope="col">Ad</th>
      <th scope="col">Soyad</th>
      <th scope="col">Mobil nömrə</th>
      <th scope="col">E-mail</th>
      <th scope="col">Cinsi</th>
      <th scope="col">Doğum tarixi</th>
      <th scope="col">Tibbi şöbə</th>
      <th scope="col">Qəbul tarixi</th>
      <th scope="col">Müraciət tarixi</th>
      <th scope="col">Qeydlər</th>
      <th scope="col">Status</th>
    </tr>
  </thead>
  <tbody>
    <%
        HospitalWebApp.WebForm1.PatientReposiotry patientReposiotry = new HospitalWebApp.WebForm1.PatientReposiotry();
        foreach (var item in patientReposiotry.GetAllData())
        {
        %>
            <tr>
              <th scope="row"><%:item.id%></th>
              <td><%:item.name%></td>
              <td><%:item.surname%></td>
              <td><%:item.phone_number%></td>
              <td><%:item.email%></td>
              <td><%:item.gender%></td>
              <td><%:item.birthday%></td>
              <td><%:item.med_department%></td>
              <td><%:item.admit_date%></td>
              <td><%:item.register_date%></td>
              <td><%:item.note%></td>
              <td><span class="label-custom label label-default"><%:item.status==true ? "Active" : "Deactive" %></span></td>
          
            </tr>
         <%} %>   
  </tbody>
</table>
        </div>
    </form>
    <br />
    <hr />
</body>
</html>
