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
          child: Form(
              key: controller.formKey,
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.center,
                children: [
                  Image.asset("assets/logo.png"),
                  Padding(
                    padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 8),
                    child: TextFormField(
                      validator: (value) {
                        if (value == null || value.isEmpty) {
                          return 'Username can\'t be empty';
                        }
                        return null;
                      },
                      controller: controller.userNameController,
                      decoration: InputDecoration(border: const OutlineInputBorder(), labelText: "Username"),
                    ),
                  ),
                  //todo: password decoration
                  Padding(
                    padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 8),
                    child: TextFormField(
                      // todo: validator builder?
                      validator: (value) {
                        if (value == null || value.isEmpty) {
                          return 'Password can\'t be empty';
                        }
                        if (value.length < 6) {
                          return 'Password has to be at least 6 characters';
                        }
                        if (!value.contains(RegExp(r"[0-9]"))) {
                          return 'Password has to contain a number';
                        }
                        if (!value.contains(RegExp(r"[A-Z]"))) {
                          return 'Password has to contain an uppercase letter';
                        }

                        return null;
                      },
                      controller: controller.passwordController,
                      obscureText: true,
                      decoration: const InputDecoration(border: OutlineInputBorder(), labelText: "Password"),
                    ),
                  ),
                  Padding(
                    padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 8),
                    child: CommonTextButton(
                      text: 'Sign in',
                      onPressed: () {
                        if (controller.formKey.currentState!.validate()) {
                          controller.onSignIn();
                        }
                      },
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
              )),
        ));
  }
}
