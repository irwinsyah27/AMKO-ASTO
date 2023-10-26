package com.sandinugraha.apps.amkoscanner.API;

import com.sandinugraha.apps.amkoscanner.Model.AssetResponse;
import com.sandinugraha.apps.amkoscanner.Model.History;
import com.sandinugraha.apps.amkoscanner.Model.HistoryResponse;

import java.util.HashMap;
import java.util.Map;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.Path;
import retrofit2.http.Query;

/**
 * Created by sandinugraha on 26/01/18.
 */

public interface ApiInterface {

    @GET("Asset/ReadAssetMob")
    Call<AssetResponse> getAsset(@Query("s_str_assetNo") String assetNumber);

    @GET("Histori/ReadHistory")
    Call<HistoryResponse> getHistories(@Query("s_str_assetNumber") String assetNumber);
}
