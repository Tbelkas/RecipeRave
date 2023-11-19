import 'package:app/ui/common_widgets/common_text_button.dart';
import 'package:app/ui/controllers/login_controller.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';

class LoginScreen extends GetView<LoginController> {
  static const routePath = '/loginscreen';
  final LoginController _orderController = Get.put(LoginController());

  LoginScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    final ButtonStyle style = ElevatedButton.styleFrom(textStyle: const TextStyle(fontSize: 20));

    return Scaffold(
        body: SafeArea(
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.center,
        children: [
          Image.asset("assets/logo.png"),
          const Padding(
            padding: EdgeInsets.symmetric(horizontal: 8, vertical: 8),
            child: TextField(
              decoration: InputDecoration(
              border: OutlineInputBorder(), hintText: "Username"),
            ),
          ),
          const Padding(
            padding: EdgeInsets.symmetric(horizontal: 8, vertical: 8),
            child: TextField(
              decoration: InputDecoration(
                  border: OutlineInputBorder(), hintText: "Password"),
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
