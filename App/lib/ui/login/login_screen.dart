import 'package:app/models/constants/colors.dart';
import 'package:app/ui/common_widgets/common_text_button.dart';
import 'package:app/ui/common_widgets/app_bar/common_app_bar.dart';
import 'package:app/ui/common_widgets/error_message/error_message_widget.dart';
import 'package:app/ui/login/login_controller.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';

class LoginScreen extends GetView<LoginController> {
  static const routePath = '/login';
  static const _screenTitle = 'Recipe rave login';

  LoginScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    final ButtonStyle style = ElevatedButton.styleFrom(textStyle: const TextStyle(fontSize: 20));

    return Scaffold(
        appBar: CommonAppBar("Recipe rave login"),
        resizeToAvoidBottomInset: false,
        body: SafeArea(
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.center,
            children: [
              Image.asset("assets/logo.png"),
              Padding(
                  padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 8),
                  child: Obx(
                    () => ErrorMessageWidget(
                      errors: controller.errors.value,
                    ),
                  )),
              Padding(
                padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 8),
                child: Obx(() => TextField(
                      controller: controller.userNameController,
                      decoration: InputDecoration(border: const OutlineInputBorder(), hintText: "Username", labelText: controller.userName.value.isEmpty ? null : controller.userName.value),
                    )),
              ),
              //todo: password decoration
              Padding(
                padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 8),
                child: TextField(
                  controller: controller.passwordController,
                  decoration: const InputDecoration(border: OutlineInputBorder(), hintText: "Password"),
                ),
              ),
              Padding(
                padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 8),
                child: CommonTextButton(
                  text: 'Sign in',
                  onPressed: controller.onSignIn,
                ),
              ),
              Padding(
                padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 8),
                child: CommonTextButton(
                  text: 'Register',
                  onPressed: controller.onRegister,
                ),
              )
            ],
          ),
        ));
  }
}
