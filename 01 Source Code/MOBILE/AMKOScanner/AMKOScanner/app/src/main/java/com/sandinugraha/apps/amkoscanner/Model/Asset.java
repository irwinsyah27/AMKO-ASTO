package com.sandinugraha.apps.amkoscanner.Model;

import com.google.gson.annotations.SerializedName;

import java.util.Date;

/**
 * Created by sandinugraha on 26/01/18.
 */

public class Asset {
    @SerializedName("PID")
    private String PID;
    @SerializedName("ASSET_NUMBER")
    private String ASSET_NUMBER;
    @SerializedName("ASSET_CODE")
    private String ASSET_CODE;
    @SerializedName("ASSET_NAME")
    private String ASSET_NAME;
    @SerializedName("ASSET_DATE")
    private String ASSET_DATE;
    @SerializedName("ASSET_DATE_STR")
    private String ASSET_DATE_STR;
    @SerializedName("ST_DATE")
    private  String ST_DATE;
    @SerializedName("ST_DATE_STR")
    private  String ST_DATE_STR;
    @SerializedName("MERK_CODE")
    private String MERK_CODE;
    @SerializedName("SN")
    private String SN;
    @SerializedName("TYPE_CODE")
    private String TYPE_CODE;
    @SerializedName("TYPE_NAME")
    private String TYPE_NAME;
    @SerializedName("NO_PR")
    private String NO_PR;
    @SerializedName("PIC")
    private String PIC;
    @SerializedName("PIC_NAME")
    private String PIC_NAME;
    @SerializedName("DEPT_CODE")
    private String DEPT_CODE;
    @SerializedName("DEPT_NAME")
    private String DEPT_NAME;
    @SerializedName("ORDER_BY")
    private String ORDER_BY;
    @SerializedName("ORDER_BY_NAME")
    private String ORDER_BY_NAME;
    @SerializedName("AMOUNT")
    private String AMOUNT;
    @SerializedName("COND_CODE")
    private String COND_CODE;
    @SerializedName("COND_NAME")
    private String COND_NAME;
    @SerializedName("UE")
    private String UE;
    @SerializedName("LOCATION_CODE")
    private String LOCATION_CODE;
    @SerializedName("LOCATION_NAME")
    private String LOCATION_NANE;
    @SerializedName("REMARK")
    private String REMARK;
    @SerializedName("LAMA_ASSET")
    private String LAMA_ASSET;
    @SerializedName("IMG")
    private String IMG;


    public Asset(String PID, String ASSET_NUMBER, String ASSET_NAME, String ASSET_CODE,String ASSET_DATE,
                 String ASSET_DATE_STR, String ST_DATE, String ST_DATE_STR, String MERK_CODE,
                 String SN, String TYPE_CODE, String TYPE_NAME, String NO_PR, String PIC,
                 String PIC_NAME, String DEPT_CODE, String DEPT_NAME, String ORDER_BY,
                 String ORDER_BY_NAME, String AMOUNT, String COND_CODE, String COND_NAME, String UE,
                 String LOCATION_CODE, String LOCATION_NANE, String REMARK, String LAMA_ASSET,
                 String IMG) {
        this.PID = PID;
        this.ASSET_NUMBER = ASSET_NUMBER;
        this.ASSET_CODE = ASSET_CODE;
        this.ASSET_NAME = ASSET_NAME;
        this.ASSET_DATE = ASSET_DATE;
        this.ASSET_DATE_STR = ASSET_DATE_STR;
        this.ST_DATE = ST_DATE;
        this.ST_DATE_STR = ST_DATE_STR;
        this.MERK_CODE = MERK_CODE;
        this.SN = SN;
        this.TYPE_CODE = TYPE_CODE;
        this.TYPE_NAME = TYPE_NAME;
        this.NO_PR = NO_PR;
        this.PIC = PIC;
        this.PIC_NAME = PIC_NAME;
        this.DEPT_CODE = DEPT_CODE;
        this.DEPT_NAME = DEPT_NAME;
        this.ORDER_BY = ORDER_BY;
        this.ORDER_BY_NAME = ORDER_BY_NAME;
        this.AMOUNT = AMOUNT;
        this.COND_CODE = COND_CODE;
        this.COND_NAME = COND_NAME;
        this.UE = UE;
        this.LOCATION_CODE = LOCATION_CODE;
        this.LOCATION_NANE = LOCATION_NANE;
        this.REMARK = REMARK;
        this.LAMA_ASSET = LAMA_ASSET;
        this.IMG = IMG;


    }


    public String getPID() {
        return PID;
    }

    public void setPID(String PID) {
        this.PID = PID;
    }

    public String getASSET_NUMBER() {
        return ASSET_NUMBER;
    }

    public void setASSET_NUMBER(String ASSET_NUMBER) {
        this.ASSET_NUMBER = ASSET_NUMBER;
    }

    public String getASSET_NAME() {
        return ASSET_NAME;
    }

    public void setASSET_NAME(String ASSET_NAME) {
        this.ASSET_NAME = ASSET_NAME;
    }

    public String getASSET_CODE() {
        return ASSET_CODE;
    }

    public void setASSET_CODE(String ASSET_CODE) {
        this.ASSET_CODE = ASSET_CODE;
    }

    public String getASSET_DATE() {
        return ASSET_DATE;
    }

    public void setASSET_DATE(String ASSET_DATE) {
        this.ASSET_DATE = ASSET_DATE;
    }

    public String getASSET_DATE_STR() {
        return ASSET_DATE_STR;
    }

    public void setASSET_DATE_STR(String ASSET_DATE_STR) {
        this.ASSET_DATE_STR = ASSET_DATE_STR;
    }

    public String getST_DATE() {
        return ST_DATE;
    }

    public void setST_DATE(String ST_DATE) {
        this.ST_DATE = ST_DATE;
    }

    public String getST_DATE_STR() {
        return ST_DATE_STR;
    }

    public void setST_DATE_STR(String ST_DATE_STR) {
        this.ST_DATE_STR = ST_DATE_STR;
    }

    public String getMERK_CODE() {
        return MERK_CODE;
    }

    public void setMERK_CODE(String MERK_CODE) {
        this.MERK_CODE = MERK_CODE;
    }

    public String getSN() {
        return SN;
    }

    public void setSN(String SN) {
        this.SN = SN;
    }

    public String getTYPE_CODE() {
        return TYPE_CODE;
    }

    public void setTYPE_CODE(String TYPE_CODE) {
        this.TYPE_CODE = TYPE_CODE;
    }

    public String getTYPE_NAME() {
        return TYPE_NAME;
    }

    public void setTYPE_NAME(String TYPE_NAME) {
        this.TYPE_NAME = TYPE_NAME;
    }

    public String getNO_PR() {
        return NO_PR;
    }

    public void setNO_PR(String NO_PR) {
        this.NO_PR = NO_PR;
    }

    public String getPIC() {
        return PIC;
    }

    public void setPIC(String PIC) {
        this.PIC = PIC;
    }

    public String getPIC_NAME() {
        return PIC_NAME;
    }

    public void setPIC_NAME(String PIC_NAME) {
        this.PIC_NAME = PIC_NAME;
    }

    public String getDEPT_CODE() {
        return DEPT_CODE;
    }

    public void setDEPT_CODE(String DEPT_CODE) {
        this.DEPT_CODE = DEPT_CODE;
    }

    public String getDEPT_NAME() {
        return DEPT_NAME;
    }

    public void setDEPT_NAME(String DEPT_NAME) {
        this.DEPT_NAME = DEPT_NAME;
    }

    public String getORDER_BY() {
        return ORDER_BY;
    }

    public void setORDER_BY(String ORDER_BY) {
        this.ORDER_BY = ORDER_BY;
    }

    public String getORDER_BY_NAME() {
        return ORDER_BY_NAME;
    }

    public void setORDER_BY_NAME(String ORDER_BY_NAME) {
        this.ORDER_BY_NAME = ORDER_BY_NAME;
    }

    public String getAMOUNT() {
        return AMOUNT;
    }

    public void setAMOUNT(String AMOUNT) {
        this.AMOUNT = AMOUNT;
    }

    public String getCOND_CODE() {
        return COND_CODE;
    }

    public void setCOND_CODE(String COND_CODE) {
        this.COND_CODE = COND_CODE;
    }

    public String getCOND_NAME() {
        return COND_NAME;
    }

    public void setCOND_NAME(String COND_NAME) {
        this.COND_NAME = COND_NAME;
    }

    public String getUE() {
        return UE;
    }

    public void setUE(String UE) {
        this.UE = UE;
    }

    public String getLOCATION_CODE() {
        return LOCATION_CODE;
    }

    public void setLOCATION_CODE(String LOCATION_CODE) {
        this.LOCATION_CODE = LOCATION_CODE;
    }

    public String getLOCATION_NANE() {
        return LOCATION_NANE;
    }

    public void setLOCATION_NANE(String LOCATION_NANE) {
        this.LOCATION_NANE = LOCATION_NANE;
    }

    public String getREMARK() {
        return REMARK;
    }

    public void setREMARK(String REMARK) {
        this.REMARK = REMARK;
    }

    public String getLAMA_ASSET() {
        return LAMA_ASSET;
    }

    public void setLAMA_ASSET(String LAMA_ASSET) {
        this.LAMA_ASSET = LAMA_ASSET;
    }

    public String getIMG() {
        return IMG;
    }

    public void setIMG(String IMG) {
        this.IMG = IMG;
    }

}
