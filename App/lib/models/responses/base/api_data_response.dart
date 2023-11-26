import 'package:app/models/responses/base/api_response.dart';

class ApiDataResponse extends ApiResponse {
  // todo: abstract serialization
  dynamic data;

  ApiDataResponse({this.data, super.errorMessages});

  ApiDataResponse.fromJson(Map<String, dynamic> json) {
    addErrors(json);
    var dataJson = json['data'];
    if(dataJson != null){
      data = json['data'];
    }
  }

  @override
  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = super.toJson();
    data['ErrorMessages'] = errorMessages;
    return data;
  }
}