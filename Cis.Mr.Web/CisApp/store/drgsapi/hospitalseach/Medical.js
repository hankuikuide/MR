﻿/* ***********************************************
 * author :  localadmin
 * function: 
 * history:  created by localadmin 2016/4/18 10:57:06 
 * ***********************************************/
Ext.define('CisApp.store.drgsapi.hospitalseach.Medical', {
    extend: 'Fm.base.Store',
    alias: 'store.hospitalseach_medical',
    model: 'CisApp.model.drgsapi.report.Medical',
    proxy: {
        type: "ajax",
        api: {
            read: '/group/Medical/GetHospitalSeachAllMedical' //SearchDataByAD//GetAllMedical
        }
    }
});