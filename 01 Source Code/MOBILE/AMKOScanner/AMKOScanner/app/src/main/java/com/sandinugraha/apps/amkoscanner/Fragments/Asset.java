package com.sandinugraha.apps.amkoscanner.Fragments;

import android.app.Dialog;
import android.app.ProgressDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.provider.ContactsContract;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.support.v7.app.AlertDialog;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import com.bumptech.glide.Glide;
import com.bumptech.glide.load.engine.DiskCacheStrategy;
import com.sandinugraha.apps.amkoscanner.API.ApiClient;
import com.sandinugraha.apps.amkoscanner.API.ApiInterface;
import com.sandinugraha.apps.amkoscanner.MainActivity;
import com.sandinugraha.apps.amkoscanner.Model.AssetResponse;
import com.sandinugraha.apps.amkoscanner.R;
import com.sandinugraha.apps.amkoscanner.ScanActivity;

import org.w3c.dom.Text;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;



public class Asset extends Fragment {

    private static final String TAG =  Asset.class.getSimpleName();
    private String params = "";
    private TextView assetNumber,assetName,assetDate,assetCode,merkCode,typeCode,sn,stDate,noPR,picName,
            deptName,orderByName,amount,condName,UE,lamaAsset,locationName,remark;
    private AlertDialog.Builder dlgAlert;
    private ImageView imageView;

    public Asset() {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        return inflater.inflate(R.layout.fragment_asset, container, false);
    }

    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {

        assetNumber = (TextView) view.findViewById(R.id.tx_asset_number);
        assetName = (TextView) view.findViewById(R.id.tx_asset_name);
        assetDate = (TextView) view.findViewById(R.id.tx_asset_date);
        assetCode = (TextView) view.findViewById(R.id.tx_asset_code);
        merkCode = (TextView) view.findViewById(R.id.tx_merk_code);
        typeCode = (TextView) view.findViewById(R.id.tx_type_code);
        sn = (TextView) view.findViewById(R.id.tx_sn);
        stDate = (TextView) view.findViewById(R.id.tx_st_date);
        noPR = (TextView) view.findViewById(R.id.tx_no_pr);
        picName = (TextView) view.findViewById(R.id.tx_pic_name);
        deptName = (TextView) view.findViewById(R.id.tx_dept_name);
        orderByName = (TextView) view.findViewById(R.id.tx_order_by_name);
        amount = (TextView) view.findViewById(R.id.tx_amount);
        condName = (TextView) view.findViewById(R.id.tx_cond_name);
        UE = (TextView) view.findViewById(R.id.tx_ue);
        locationName = (TextView) view.findViewById(R.id.tx_location_name);
        lamaAsset = (TextView) view.findViewById(R.id.tx_lama_asset);
        remark = (TextView) view.findViewById(R.id.tx_remark);
        imageView = (ImageView) view.findViewById(R.id.img_asset);

        final Intent intent = new Intent(getActivity(), MainActivity.class);

        dlgAlert  = new AlertDialog.Builder(getActivity());
        dlgAlert.setMessage("Server tidak di temukan !");
        dlgAlert.setTitle("Terjadi Kesalahan");

        dlgAlert.setPositiveButton("Ok",
                new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int which) {
                        startActivity(intent);
                        getActivity().finish();
                    }
                });



        final ProgressDialog progressDoalog;
        progressDoalog = new ProgressDialog(getActivity());
        progressDoalog.setMax(100);
        progressDoalog.setMessage("Loading...");
        progressDoalog.setTitle("Mengambil data dari server");
        progressDoalog.setProgressStyle(ProgressDialog.STYLE_SPINNER);
        // show it
        progressDoalog.show();


        params = getActivity().getIntent().getStringExtra("code");

        ApiInterface apiService = ApiClient.getClient().create(ApiInterface.class);

        Call<AssetResponse> call = apiService.getAsset(params);
        call.enqueue(new Callback<AssetResponse>() {
            @Override
            public void onResponse(Call<AssetResponse> call, Response<AssetResponse> response) {
                com.sandinugraha.apps.amkoscanner.Model.Asset asset = response.body().getData();
                Log.d(TAG,"STR DATE :" + asset.getASSET_DATE_STR());

                assetNumber.setText(asset.getASSET_NUMBER());
                assetName.setText(asset.getASSET_NAME());
                assetDate.setText(asset.getASSET_DATE_STR());
                assetCode.setText(asset.getASSET_CODE());
                merkCode.setText(asset.getMERK_CODE());
                typeCode.setText(asset.getTYPE_CODE());
                sn.setText(asset.getSN());
                stDate.setText(asset.getST_DATE_STR());
                noPR.setText(asset.getNO_PR());
                picName.setText(asset.getPIC_NAME());
                deptName.setText(asset.getDEPT_NAME());
                orderByName.setText(asset.getORDER_BY_NAME());
                amount.setText(asset.getAMOUNT());
                condName.setText(asset.getCOND_NAME());
                UE.setText(asset.getUE());
                locationName.setText(asset.getLOCATION_NANE());
                lamaAsset.setText(asset.getLAMA_ASSET());
                remark.setText(asset.getREMARK());

                Glide.with(getContext()).load(ApiClient.BASE_URL + asset.getIMG())
                                        .thumbnail(0.5f)
                                        .crossFade()
                                        .diskCacheStrategy(DiskCacheStrategy.ALL)
                                        .into(imageView);


                progressDoalog.dismiss();
            }

            @Override
            public void onFailure(Call<AssetResponse> call, Throwable t) {
                Log.e(TAG,t.toString());
                progressDoalog.dismiss();

                dlgAlert.create().show();

            }
        });
    }


}
