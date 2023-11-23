import 'package:app/ui/controllers/login_controller.dart';
import 'package:app/ui/controllers/register_controller.dart';
import 'package:app/ui/screens/register_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:get/get.dart';
import 'package:get_storage/get_storage.dart';
import 'package:google_fonts/google_fonts.dart';

import 'ui/screens/login_screen.dart';

void main() async {
  await GetStorage.init();
  Get.put(LoginController());
  Get.put(RegisterController());
  runApp(MyApp());
  SystemChrome.setSystemUIOverlayStyle(SystemUiOverlayStyle(
    statusBarColor: Colors.blue.shade50,
  ));
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return GetMaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'Login',
      theme: ThemeData(
        primarySwatch: Colors.blue,
        canvasColor: Colors.blue.shade50,
        textTheme: TextTheme(
          headline6: GoogleFonts.montserrat(
            color: Colors.black,
            fontWeight: FontWeight.w500,
            letterSpacing: 2.0,
            fontSize: 16.0,
          ),
          headline5: GoogleFonts.indieFlower(
            color: Colors.black,
            fontWeight: FontWeight.w500,
            letterSpacing: 2.0,
            fontSize: 20.0,
          ),
          headline4: GoogleFonts.montserrat(
            color: Colors.white,
            letterSpacing: 2.0,
            fontWeight: FontWeight.w500,
            fontSize: 24.0,
          ),
        ),
      ),
      initialRoute: LoginScreen.routePath,
      getPages: [
        GetPage(
          name: LoginScreen.routePath,
          page: () => LoginScreen(),
        ),
        GetPage(
          name: RegisterScreen.routePath,
          page: () => RegisterScreen(),
        )
      ],
    );
  }
}
