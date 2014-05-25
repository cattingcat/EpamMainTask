<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CaptchaUserControl.ascx.cs" Inherits="WebClient.Patrials.CaptchaUserControl" %>
<div class="col-sm-4">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3 class="panel-title">Captcha</h3>
        </div>
        <div class="panel-body">
            <img src="/captcha.jpg" />
            <input type="number" name="captcha" id="captchaField" runat="server"/>
        </div>
    </div>
</div>