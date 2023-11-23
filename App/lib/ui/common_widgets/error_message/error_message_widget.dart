import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class ErrorMessageWidget extends StatelessWidget {
  final List<String> errors;
  final double midWidth;
  final double minHeight;

  const ErrorMessageWidget({required this.errors, this.midWidth = 2000, this.minHeight = 60, super.key});
  @override
  Widget build(BuildContext context) {
    return ConstrainedBox(
      constraints: BoxConstraints(minHeight: minHeight, minWidth: midWidth),
      child: Column( children: errors.map((e) => Text(e)).toList() )
    );
  }
}