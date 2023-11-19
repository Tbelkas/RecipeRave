import 'package:app/ui/common_widgets/common_text_button.dart';
import 'package:app/ui/controllers/login_controller.dart';
import 'package:app/ui/controllers/register_controller.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';

class RegisterScreen extends GetView<RegisterController> {
  static const routePath = '/register';

  const RegisterScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: SafeArea(
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.center,
        children: [
          Image.asset("assets/logo.png"),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 8),
            child: TextField(
              controller: controller.userNameController,
              decoration: const InputDecoration(
                  border: OutlineInputBorder(), hintText: "Username"),
            ),
          ),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 8),
            child: TextField(
              controller: controller.passwordController,
              decoration: const InputDecoration(
                  border: OutlineInputBorder(), hintText: "Password"),
            ),
          ),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 8),
            child: TextField(
              controller: controller.confirmPasswordController,
              decoration: InputDecoration(
                  border: OutlineInputBorder(), hintText: "Confirm password"),
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
