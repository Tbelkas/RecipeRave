import 'package:app/models/requests/network_request.dart';
import 'package:app/models/requests/network_request_type.dart';
import 'package:app/models/responses/base/api_data_response.dart';
import 'package:app/models/responses/base/api_response.dart';
import 'package:app/models/responses/login_response.dart';
import 'package:app/services/network_service.dart';
import 'package:app/ui/models/login_model.dart';
import 'package:app/ui/models/register_model.dart';

class AuthService {
  final NetworkService _network_service;

  AuthService() : _network_service = NetworkService(baseUrl: "http://10.0.2.2:5218/Auth");

  Future<ApiResponse> register(RegisterModel registerModel) async{
    var networkRequest = NetworkRequest(type: NetworkRequestType.POST, path: "/Register", data: registerModel);
    var result = await _network_service.execute<RegisterModel>(networkRequest);
    return result;
  }

  Future<ApiDataResponse> login(LoginModel loginModel) async{
    var networkRequest = NetworkRequest(type: NetworkRequestType.POST, path: "/Login", data: loginModel);
    var result = await _network_service.execute<LoginModel>(networkRequest);
    return result;
  }
}