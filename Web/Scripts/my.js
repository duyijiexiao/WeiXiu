////////////维修申请//////////

////////////手机验证码//////////
function updatePwdPage() {
    var b = jQuery("#validPhoneCode").val();
    if (b == "" || b.length != 6) {
        $("#validPhoneCode_wrong").show();
        jQuery("#validPhoneCode_wrong").parents("li").addClass("cur_error");
        return
    }
    var c = { validCode: b };

    jQuery.post('', c, function (d) {
        if (d) {
            if (d.errorCode == "0") {
                window.location = "/" + +$("#BiaoShi").val() + "/Passport/NewPassword/";
                return
            }
            if (d.errorCode == "1") {
                alert('验证码已经过期，请重新申请找回密码');
                window.location = "/" + $("#BiaoShi").val() + "/Passport/Index/";
                return
            }

         
        }
    })
}

function updatePwdSubmit() {

    if (doSubmitPwd("password_mobile")) {
        //提交服务器
        var e = {
            newpassword: $("#password_mobile").val(),
            password: $("#password_mobile2").val()
        };
        $.post("", e, function (i) {
            if (i) {
                if (i.errorCode == 0) {
                    window.location = "/" + +$("#BiaoShi").val() + "/Passport/Success";
                }
                else if (i.errorCode == 1) {
                    alert('新密码设置失败');
                    return

                }

            }
        })
        return true
    }


};
////////////找回密码//////////

function confirmUser() {
    if (!checkAccount_beforeFind())
    { return false }
    var c = {
        phone: $("#phone").val(), validCode: $("#vcd").val()
    };

    jQuery.post("", c, function (d) {
        if (d) {
            if (d.errorCode == "0") {
                window.location = "/" + $("#BiaoShi").val() + "/Passport/FindPassword/";
            }
            if (d.errorCode == "1") {
                refresh_valid_code1();
                $("#vcd").focus();
                $("#vcd_desc").show();
                jQuery("#vcd_desc").parents("li").addClass("cur_error");
                return
            }
            if (d.errorCode == "2") {
                refresh_valid_code1();
                showPhoneError("您输入正确的手机号");
                return
            }
            
            if (d.errorCode == "4") {
                refresh_valid_code1();
                showPhoneError("您输入的账号未找到记录");
               

                return
            }

            if (d.errorCode == "5") {
                refresh_valid_code1();
                showPhoneError("您的账户还未审核，预计1个工作日内处理完毕");
                return
            }
            if (d.errorCode == "6") {
                refresh_valid_code1();
                $("#vcd").focus();
                $("#vcd_desc").text("验证码过期");
                $("#vcd_desc").show();
                jQuery("#vcd_desc").parents("li").addClass("cur_error");
                return
            }
            if (d.errorCode == "15") {
                refresh_valid_code1();
                showPhoneError("抱歉，您的账号已经使用找回密码超过5次，请联系管理员");
             
                return
            }
        }
    })
}
function refresh_valid_code1() {
    var b = new Date();
    var a = "/4/Vc/Index";
    $("#valid_code_pic").attr("src", a + "?id=" + b)
}

function checkAccount_beforeFind() {
    if ($("#phone").val() == "" || $("#phone").val() == "请输入手机号") {
        $("#phone_desc").text("请输入手机号");
        $("#phone").focus();
        $("#phone_desc").show();
        return false
    }
    if ($("#vcd").val() == "") {
        $("#vcd").focus();
        $("#vcd_desc").show();
        jQuery("#vcd_desc").parents("li").addClass("cur_error");
        return false
    }
    if ($("#vcd").val().length != 4) {
        $("#vcd").focus();
        $("#vcd_desc").attr("style", "display:inline-block");
        return false
    }
    return true
}

////////////注册//////////


var commonSymbol = "[\\,\\`\\~\\!\\@@\\#\\$\\%\\\\^\\&\\*\\(\\)\\-\\_\\=\\+\\[\\{\\]\\}\\\\|\\;\\:\\‘\\’\\“\\”\\<\\>\\/?]+";

function checkPassword2OnBlur(b) {
    var a = check_pwd2(b);
    if (a == 1) {
        showPass2Error(b, "确认密码不能为空")
    }
    else {
        if (a == 2) {
            showPass2Error(b, "两次密码输入不一致")
        }
        else {
            $("#" + b + "2_desc").show();
            $("#" + b + "2_error").hide();
            $("#" + b + "2_tip").hide();

            jQuery("#" + b + "2").parents("li").removeClass("cur_error")
        }
    }
}
function check_pwd2(a) {
    var c = $("#" + a).val();
    var b = $("#" + a + "2").val();
    if (b == "")
    { return 1 }
    if (c != b)
    { return 2 }
    return 0
}
function showPass2Error(a, b) {
    jQuery("#" + a + "2_tip").hide();
    showErrorInfo(a + "2_error", b)
}
function isSameWord(d) {
    var b;
    if (d != null && d != "") {
        b = d.charCodeAt(0);
        b = "\\" + b.toString(8);
        var a = "[" + b + "]{" + (d.length) + "}";
        var c = new RegExp(a);
        return c.test(d)
    }
    return true
}

function checkPassWordContent(b) {
    jQuery("#" + b).parents("li").removeClass("cur_error");
    var a = jQuery("#" + b).val();
    if (a.length > 0) {

    }
    else { hideOtherTips(b) }
}

function passwordOnFocus(b) {

    var a = jQuery("#" + b);
    if (a.val() == "") {
        hideOtherTips(b); return
    }
    checkPassWordContent(b);
    hideOtherTips(b + "2");
    showoff(b + "2_desc");

}

function showPassError(a, b) {
    jQuery("#" + a + "_tip").hide();
    jQuery("#" + a + "_desc").hide();

    showErrorInfo(a + "_error", b)
}
function check_pwd1(g) {
    var h = $("#" + g).val();
    if (h == "")
    {
        showPassError(c, "密码不能为空");
        return 1
    }
    if (h.length > 20||h.length < 6)
    {
        showPassError(c, "密码为6-20位字符");
        return 2
    }
   
    var f = /\s+/;
    if (f.test(h))
    {
        showPassError(c, "密码中不允许有空格");
        return 4
    }
    var a = /^[0-9]+$/;
    if (a.test(h))
    {
        showPassError(c, quanweishuzi);
        return 5
    }
    var b = /^[a-zA-Z]+$/;
    if (b.test(h))
    {
        showPassError(c, "密码不能全为字母，请包含至少1个数字或符号 ");
        return 6
    }
    var i = /^[^0-9A-Za-z]+$/;
    if (i.test(h))
    {
        showPassError(c, "密码不能全为符号");
        return 7
    }
    if (isSameWord(h))
    {
        showPassError(c, "密码不能全为相同字符或数字");
        return 8
    }
   
    return 0
}

function checkPasswordOnBlur(c) {
    hideOtherTips(c);
    var a = check_pwd1(c);
    if (a == 0) { 
        jQuery("#" + c + "2").removeAttr("readonly");//liutengfei
        jQuery("#password_mobile_error").hide();
        jQuery("#password_mobile_tip").hide();
        $("#password_mobile_desc").css("display", "block");
        jQuery("#password_mobile").parents("li").removeClass("cur_error")

        return;
    } else {

        jQuery("#" + c + "2").attr("readonly", "readonly")
        
    }
}
function phoneOnFocus(a) {
    $("#" + a + "").removeClass("gay_text");//字体变化
    if (jQuery("#" + a + "").val() == "请输入手机号码") {
        jQuery("#" + a + "").val("");
    }

    hideOtherTips(a);
    return

}
function phoneOnFocusVcd(a) {
    $("#" + a + "").removeClass("gay_text");//字体变化
    if (jQuery("#" + a + "").val() == "验证码") {
        jQuery("#" + a + "").val("");
    }

    return

}
function hideOtherTips(a) {


    if (jQuery("#" + a + "").val() == "") {
        jQuery("#" + a + "_error").hide();
        jQuery("#" + a + "_tip").show()
    }
    jQuery("#" + a + "").parents("li").removeClass("cur_error")
}
function showoff(b) {
    var a = b.split("_");
    if (a[0] != "password") {

        jQuery("#" + a[0] + "_error").hide();
        jQuery("#" + a[0] + "_tip").show()
    }
    jQuery("#" + b + "").hide()
}
function check_phone() {
    var a = jQuery("#phone").val();
    if (a == "" || a == "请输入手机号码") {
        return 1
    }
    var b = /^1\d{10}$/;
    if (!b.test(a)) {
        return 2
    }
    return 0
}
function showPhoneError(a) {
    jQuery("#phone_tip").hide();
    showErrorInfo("phone_error", a)
}
function showErrorInfo(b, a) {
    jQuery("#" + b).html("<u></u>" + a + "").show();
    jQuery("#" + b).parents("li").addClass("cur_error");
    var c = b.split("_");
    jQuery("#" + c[0] + "_desc").hide()
}

function checkPhoneOnBlur() {
    var a = check_phone();
    if (a == 1) {
        showPhoneError(qingshuruzhanghao)
    } else {
        if (a == 2) {
            showPhoneError(zhengqueshoujihao)
        }
        else {

            jQuery("#phone_tip").hide();
            $("#phone_desc").css("display", "block");
            jQuery("#phone").parents("li").removeClass("cur_error")

            //$.ajax({
            //    type: "POST",
            //    url: "/check/check_phone",
            //    data: { validPhone: $("#phone").val() },
            //    success: function (b) {
            //        if (b.checkResult == 0) {
            //            jQuery("#phone_tip").hide();
            //            $("#phone_desc").css("display", "block");
            //            jQuery("#phone").parents("li").removeClass("cur_error")
            //        }
            //        else {
            //            if (b.checkResult == 1) {
            //                showPhoneError("该手机号已存在，<a href='/Account/Login'>登录</a>")
            //            }
            //        }
            //    }
            //})
        }
    }
}
function doPhoneSubmit(c) {
    if (doSubmitPwd(c) == false) {
        return false
    }
    var d = check_phone();
    if (d == 1) {
        showPhoneError(qingshuruzhanghao);
        return false
    } else {
        if (d == 2) {
            showPhoneError(zhengqueshoujihao);
            return false
        }
    }
    return true
}
function doSubmitPwd(f) {
    var e = check_pwd1(f);
    if (e!=0) {
        return false
    }
    
    var d = check_pwd2(f);
    if (d == 1) {
        showPass2Error(f, querenmima);
        return false
    } else {
        if (d == 2) {
            showPass2Error(f, liangcimima);
            return false
        }
    }
    return true;//liutengfei
};
var qingshuruzhanghao = '请输入账号'
     , qingshurumima = '请输入密码'
      , zhanghaochangdu = '账号长度不能超过50位'
        , mimachangdu = '6-20个大小写英文字母、符号或数字'
 , feifazifu = '账号中包含非法字符'
 , mimabunengyoukongge = '密码不能有空格'
 , bupipei = '账号和密码不匹配，请重新输入'
 , weishenhe = '您的账号尚未审核通过，请等待'
 , cunzaiyichang = '您的账号存在异常，请联系管理员'
, quanweishuzi = '密码不能全为数字'
,querenmima = '确认密码不能为空'
, liangcimima = '两次密码输入不一致'
, zhengqueshoujihao = '请输入正确的手机号'
, shoujihaocuanzai = '该手机号已存在'

;
function registerByPhoneSubmit() {

    if (!doPhoneSubmit('password_mobile')) {
        return;
    }

    var phone = $("#phone").val();
    var password = $("#password_mobile").val();
    var password2 = $("#password_mobile2").val();

    var RegisterViewModel = {
        UserName: phone,
        Password: password,
        ConfirmPassword: password2,
        BiaoShi: $("#BiaoShi").val()
    }
    jQuery.post("", RegisterViewModel, function (i) {
        if (i.errorCode == 11) {
            showPassError("password_mobile", cunzaiyichang);
 
        }
        if (i.errorCode == 0) {
            alert("注册成功，请等待管理员审核");
        } else if (i.errorCode == 1) {
            showPassError("password_mobile", qingshurumima);
        }
        else if (i.errorCode == 2) {
            showPassError("password_mobile", mimachangdu);
        }
        else if (i.errorCode == 5) {
            showPassError("password_mobile", quanweishuzi);
        }
        else if (i.errorCode == 9) {
            showPass2Error("password_mobile", liangcimima);
        }

        else if (i.errorCode == 20) {
            showPhoneError(qingshuruzhanghao);
        }
        else if (i.errorCode == 21) {
            showPhoneError(zhanghaochangdu);
        }
        else if (i.errorCode == 22) {
            showPhoneError(zhengqueshoujihao);
        }
        else if (i.errorCode == 23) {
            showPhoneError(shoujihaocuanzai);
        }
        else if (i.errorCode == 99) {
            alert(i.content);
        }

    });
}

////////////登录//////////
function checkagreement() {
    if ($("#check_agreement").hasClass("uncheck_agreement")) {
        $("#autoLoginCheck").val(false);
        $("#check_agreement").attr("class", "check_agreement");

        $("#agreement_tips").show();
    } else {

        $("#autoLoginCheck").val(true);
        $("#check_agreement").attr("class", "uncheck_agreement");

        $("#agreement_tips").hide();
    }
    return false;

}
function showErrorInfoLogin(a, b) {
    $("#error_tips").text(b);
    $("#error_tips").show();
    $(a).focus();
}
function stringTrim(a) {
    return a.replace(/(^\s*)|(\s*$)/g, "");
}
function stringLen(b) {
    b = stringTrim(b);
    var a = 0;
    if (b) {
        a = b.replace(/[^\x00-\xff]/g, "***").length;
    }
    return a;
}


function double_submit() {
    $("#error_tips").hide();
    var a = $("#UserName").val();
    var c = $("#Password").val();
    if (a == "") {
        showErrorInfoLogin("#UserName", qingshuruzhanghao);
        return false;
    }
    if (c == "") {
        showErrorInfoLogin("#Password", qingshurumima);
        return false;
    }

    if (stringLen(a) > 50) {
        showErrorInfoLogin("#UserName", zhanghaochangdu);
        return false;
    }
    if (stringLen(c) > 20 || stringLen(c) < 6) {
        showErrorInfoLogin("#Password", mimachangdu);
        return false;
    }

    if (a.toLowerCase().indexOf("<script") > -1 || a.toLowerCase().indexOf("<\/script") > -1) {
        showErrorInfoLogin("#UserName", feifazifu);
        return false;
    }

    var b = /\s+/;
    if (b.test(c)) {
        showErrorInfoLogin("#Password", mimabunengyoukongge);
        return false;
    }

    var LoginViewModel = {
        UserName: a,
        Password: c,
        BiaoShi: $("#BiaoShi").val(),
        RememberMe: $("#autoLoginCheck").val()
    };
    $.post("", LoginViewModel, function (i) {
        if (i) {
            if (i.errorCode == 0) {

                window.location = "/Apply";
            }
            else if (i.errorCode == 1) {

                showErrorInfoLogin("#UserName", bupipei);

            }
            else if (i.errorCode == 2) {
                showErrorInfoLogin("#UserName", qingshuruzhanghao);

            }
            else if (i.errorCode == 3) {
                showErrorInfoLogin("#Password", qingshurumima);

            }
            else if (i.errorCode == 4) {
                showErrorInfoLogin("#UserName", zhanghaochangdu);

            }
            else if (i.errorCode == 5) {
                showErrorInfoLogin("#Password", mimachangdu);

            }
            else if (i.errorCode == 6) {
                showErrorInfoLogin("#UserName", weishenhe)
            }
            else if (i.errorCode == 11) {
                showErrorInfoLogin("#UserName", cunzaiyichang)
            }
        }
    })
}


