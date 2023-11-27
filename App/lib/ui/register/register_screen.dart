import 'package:app/ui/common_widgets/common_text_button.dart';
import 'package:app/ui/common_widgets/app_bar/common_app_bar.dart';
import 'package:app/ui/common_widgets/error_message/error_message_widget.dart';
import 'package:app/ui/register/register_controller.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';

class RegisterScreen extends GetView<RegisterController> {
  static const routePath = '/register';
  static const _screenTitle = 'Recipe rave registration';

  const RegisterScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        resizeToAvoidBottomInset: false,
        appBar: const CommonAppBar(_screenTitle),
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
                      decoration: const InputDecoration(border: OutlineInputBorder(), labelText: "Username"),
                    ),
                  ),
                  Padding(
                    padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 8),
                    child: TextFormField(
                      validator: (value) {
                        if (value == null || value.isEmpty) {
                          return 'Email can\'t be empty';
                        }

                        // todo : regex email
                        if (!value.contains('@')) {
                          return "Invalid email";
                        }
                        return null;
                      },
                      controller: controller.emailController,
                      decoration: const InputDecoration(border: OutlineInputBorder(), labelText: "Email"),
                    ),
                  ),
                  Padding(
                    padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 8),
                    child: TextFormField(
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
                      decoration: const InputDecoration(border: OutlineInputBorder(), labelText: "Password", ),
                    ),
                  ),
                  Padding(
                    padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 8),
                    child: TextFormField(
                      validator: (value) {
                        if (value == null || value != controller.passwordController.value.text) {
                          return 'Password doesn\'t match';
                        }
                        return null;
                      },
                      controller: controller.confirmPasswordController,
                      obscureText: true,
                      decoration: const InputDecoration(border: OutlineInputBorder(), labelText: "Confirm password"),
                    ),
                  ),
                  Padding(
                      padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 8),
                      child: CommonTextButton(
                          text: 'Register',
                          onPressed: () {
                            if (controller.formKey.currentState!.validate()) {
                              controller.onRegister();
                            }
                          })),
                ],
              )),
        ));
  }
}
