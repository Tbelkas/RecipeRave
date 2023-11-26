import 'package:app/models/constants/colors.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class CommonAppBar extends StatelessWidget implements PreferredSizeWidget {
  final String text;
  // todo: inheritence instead of flag?
  final bool shouldDisplayLogout;
  const CommonAppBar(this.text, {super.key, this.shouldDisplayLogout = false});

  @override
  Widget build(BuildContext context) {
    return Padding(padding: EdgeInsets.only(bottom: 8), child: AppBar(

      centerTitle: true,
      title: Text(text),
      backgroundColor: PRIMARY_COLOR,
      titleTextStyle: const TextStyle(
        color: Colors.black,
        fontSize: 24,
      ),
      leading: shouldDisplayLogout ? Padding(
        padding: const EdgeInsets.symmetric(vertical: 4, horizontal: 8),
        child: ElevatedButton(

            style: ElevatedButton.styleFrom(
                backgroundColor: ACCENT_COLOR,
                shape: const RoundedRectangleBorder(borderRadius: BorderRadius.zero),
                textStyle: const TextStyle(fontSize: 12),
                padding: const EdgeInsets.symmetric(vertical: 8, horizontal: 2),
                side: const BorderSide(width: 2.0, color: ACCENT_COLOR)),
            onPressed: () {},
            child: const Text("Log out")),
      ) : null,
      leadingWidth: shouldDisplayLogout ? 80 : null,
      shape: const Border(
          bottom: BorderSide(
              color: ACCENT_COLOR,
              width: 2
          )
      ),
    ));
  }

  // todo: better solution
  static final _appBar = AppBar();

  @override
  Size get preferredSize => _appBar.preferredSize;
}
