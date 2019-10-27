function resetPassword() {
    var cellphone = $("#Cellphone").val();
    $.ajax({
        method: "POST",
        url: "/Account/ResetPasswordModal",
        data: { cellphone: cellphone }
    })
  .done(function (msg) {
      $("#resetMessage").html(msg);
      alert($("#resetMessage").html());
      ("#myModal").hide();
  });
}