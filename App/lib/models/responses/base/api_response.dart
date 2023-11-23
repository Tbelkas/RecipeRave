class ApiResponse {
  List<String>? errorMessages;
  bool get isSuccess => errorMessages == null;

  ApiResponse({this.errorMessages});

  ApiResponse.fromJson(Map<String, dynamic> json) {
    var errorsJson = json['errorMessages'];
    if(errorsJson == null) {
      return;
    }
    errorMessages = json['errorMessages'].cast<String>();
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['ErrorMessages'] = errorMessages;
    return data;
  }
}