import 'package:app/models/constants/storage_keys.dart';
import 'package:app/models/requests/network_request.dart';
import 'package:app/models/requests/network_request_type.dart';
import 'package:app/models/responses/base/api_data_response.dart';
import 'package:app/models/responses/base/api_response.dart';
import 'package:app/services/network_service.dart';
import 'package:app/ui/login/models/login_model.dart';
import 'package:app/ui/register/models/register_model.dart';
import 'package:get_storage/get_storage.dart';

class AuthService {
  final NetworkService _networkService;

  AuthService() : _networkService = NetworkService(baseUrl: "http://10.0.2.2:5218/Auth");

  Future<ApiResponse> register(RegisterModel registerModel) async{
    var networkRequest = NetworkRequest(type: NetworkRequestType.POST, path: "/Register", data: registerModel);
    var result = await _networkService.execute(networkRequest);
    return result;
  }

  Future<ApiDataResponse> login(LoginModel loginModel) async{
    var networkRequest = NetworkRequest(type: NetworkRequestType.POST, path: "/Login", data: loginModel);
    var result = await _networkService.execute(networkRequest);
    return result;
  }

  // todo: Simulate a logout by just deleting the token
  Future<ApiResponse> logout() async{
    GetStorage().remove(tokenKey);

    // var networkRequest = NetworkRequest(type: NetworkRequestType.POST, path: "/Login", data: loginModel);
    // var result = await _networkService.execute(networkRequest);
    return ApiResponse();
  }
}