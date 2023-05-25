<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchPatient.aspx.cs" Inherits="HospitalWebApp.SearchPatient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit_Patient</title>
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="https://getbootstrap.com/docs/5.3/assets/css/docs.css" rel="stylesheet"/>
</head>
<body style="background-color:#8cff9e;">
    <center><img src = "HealthCare.png" width = "25%" height = "25%"></center>
    <form id="form1" runat="server">
        <div class="container">
            
            <div class="row">
                <div class="col">
                     
                </div>
            </div>
            <hr />
            <label for="exampleFormControlInput1" id="Username" runat="server" class="form-label" style="margin-left:65%;margin-right:5px; text-decoration: underline; font-size:20px; "></label>
            <button type="button" id="logout_btn2" class="btn btn-secondary" runat="server" onserverclick="logout_btn2_ServerClick">Log out</button>             
                        
            <br />
            <div class="row">
                
                <div class="col-3">
                    <label for="exampleFormControlInput1" class="form-label">Telefon nömrəsini daxil edin:</label>
                </div>
                <div class="col-3">
                    <input class="form-control" id="patientPhone" type="text"  runat="server" placeholder="..." aria-label="default input example"/>
                </div>
                <div class="col-6">
                     <button type="button" id="search_btn2" class="btn btn-primary" runat="server" onserverclick="search_btn2_ServerClick">Axtar</button>
                     <button type="button" id="cancel2" class="btn btn-secondary" runat="server" onserverclick="cancel2_ServerClick">Geri</button> 
                </div>
            </div>
            <hr />
            <br />
            
            <div class="row">
                <div class="col-3">
                    <label for="exampleFormControlInput1" class="form-label">Ad</label>
                    <input class="form-control" id="name" type="text"  runat="server" placeholder="Ad" aria-label="default input example"/>
                </div>
                 <div class="col-3">
                     <label for="exampleFormControlInput1" class="form-label">Soyad</label>
                    <input class="form-control" id="surname" type="text"  runat="server" placeholder="Soyad" aria-label="default input example"/>
                </div>
                 <div class="col-3">
                     <label for="exampleFormControlInput1" class="form-label">Mobil nömrə</label>
                    <input class="form-control" id="phoneNumber" type="text"  runat="server" placeholder="+994*********" aria-label="default input example"/>
                </div>
                <div class="col-3">
                    <label for="exampleFormControlInput1" class="form-label">E-mail</label>
                    <input class="form-control" id="email" type="text"  runat="server" placeholder="example@domain.com" aria-label="default input example"/>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-3">
                    <label for="exampleFormControlInput1" class="form-label">Doğum tarixi</label>
                    <input class="form-control" id="birthday" type="text" runat="server" placeholder="format: dd.mm.yyyy" aria-label="default input example"/>
                </div>
                <div class="col-1">
                        <label for="exampleFormControlInput1" class="form-label">Cinsi</label>
                        <div class="form-check">
                                    <input class="form-check-input" runat="server" value="Male" type="radio" name="flexRadioDefault" id="flexRadioDefault1"/>
                                    <label class="form-check-label" for="flexRadioDefault1">
                                    Kişi
                                    </label>
                        </div>
                        <div class="form-check form-check-inline">
                                    <input class="form-check-input" runat="server" value="Female" type="radio" name="flexRadioDefault" id="flexRadioDefault2"/>
                                    <label class="form-check-label" for="flexRadioDefault2">
                                    Qadın
                                    </label>
                        </div>
                </div>
                <div class="col-4">
                            <label for="exampleFormControlInput1" class="form-label">Tibbi şöbə</label>
                             <select class="form-select" id="medDepartment" runat="server" aria-label="Default select example">
                                    <option tabindex="0" value="----">Seçin</option>
                                    <option tabindex="1" value="Endoskopiya">Endoskopiya</option>
                                    <option tabindex="2" value="Fizioterapiya">Fizioterapiya</option>
                                    <option tabindex="3" value="Kardiologiya">Kardiologiya</option>
                                    <option tabindex="4" value="Laboratoriya">Laboratoriya</option>
                                    <option tabindex="5" value="Nevrologiya">Nevrologiya</option>
                                    <option tabindex="6" value="Oftalmologiya">Oftalmologiya</option>
                                    <option tabindex="7" value="Pediatriya">Pediatriya</option>
                                    <option tabindex="8" value="Stomotologiya">Stomotologiya</option>
                            </select>
                </div>
                <div class="col-4">
                    <label for="exampleFormControlInput1" class="form-label">Qəbul tarixi</label>
                    <input class="form-control" id="admitDate" type="text" runat="server" placeholder="format: dd.mm.yyyy" aria-label="default input example"/>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-6">
                    <label for="exampleFormControlTextarea1" class="form-label">Əlavə qeydlər</label>
                    <textarea class="form-control" id="note" rows="2" runat="server"></textarea>
                </div>
                <div class="col-6">
                    <br />
                    <input class="form-check-input" type="checkbox" value="" id="checkAdmit" runat="server">
                    <label class="form-check-label" for="flexCheckDefault">Qəbula düşəcək</label>
                    <br />
                    <button type="button" id="edit_btn" class="btn btn-primary" runat="server" onserverclick="edit_btn_ServerClick">Yadda saxla</button>
                             
                    <button type="button" id="remove_btn" class="btn btn-secondary" runat="server" onserverclick="remove_btn_ServerClick">Sil</button>             
           

                </div>
            </div>
            <br />
            <hr />


        </div>
    </form>
</body>
</html>
