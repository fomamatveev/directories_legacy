using System.Data.Common;
using Dapper;
using DL.Migrator.Data;

namespace DL.Migrator.Migrations;

internal class MigrationInsertTestData(DbConnection databaseConnection) : MigrationBase(databaseConnection, 2)
{
    private const string ProductData = @"
INSERT INTO ""Product""
(""Id"", ""Name"", ""ShortName"", ""CreatedAt"", ""CreatedBy"", ""UpdatedAt"", ""UpdatedBy"", ""Description"", ""Quantity"", ""ProductTypeId"", ""StorageLocationId"", ""ProductNameId"")
VALUES(1, NULL, NULL, '2025-05-03 15:25:48.549', 1, '2025-05-03 15:25:48.560', 1, NULL, 1, 6, 1, 3);
INSERT INTO ""Product""
(""Id"", ""Name"", ""ShortName"", ""CreatedAt"", ""CreatedBy"", ""UpdatedAt"", ""UpdatedBy"", ""Description"", ""Quantity"", ""ProductTypeId"", ""StorageLocationId"", ""ProductNameId"")
VALUES(2, NULL, NULL, '2025-05-03 15:26:57.155', 1, '2025-05-03 15:26:57.155', 1, NULL, 12, 3, 3, 2);
INSERT INTO ""Product""
(""Id"", ""Name"", ""ShortName"", ""CreatedAt"", ""CreatedBy"", ""UpdatedAt"", ""UpdatedBy"", ""Description"", ""Quantity"", ""ProductTypeId"", ""StorageLocationId"", ""ProductNameId"")
VALUES(3, NULL, NULL, '2025-05-03 15:27:09.847', 1, '2025-05-03 15:27:09.847', 1, NULL, 4, 3, 11, 1);
INSERT INTO ""Product""
(""Id"", ""Name"", ""ShortName"", ""CreatedAt"", ""CreatedBy"", ""UpdatedAt"", ""UpdatedBy"", ""Description"", ""Quantity"", ""ProductTypeId"", ""StorageLocationId"", ""ProductNameId"")
VALUES(4, NULL, NULL, '2025-05-03 15:27:21.246', 1, '2025-05-03 15:27:21.246', 1, NULL, 2, 6, 1, 4);
INSERT INTO ""Product""
(""Id"", ""Name"", ""ShortName"", ""CreatedAt"", ""CreatedBy"", ""UpdatedAt"", ""UpdatedBy"", ""Description"", ""Quantity"", ""ProductTypeId"", ""StorageLocationId"", ""ProductNameId"")
VALUES(5, NULL, NULL, '2025-05-03 15:27:35.316', 1, '2025-05-03 15:27:35.316', 1, NULL, 6, 6, 6, 5);
";
    
    private const string ProductNameData = @"
INSERT INTO ""ProductName""
(""Id"", ""Name"", ""ShortName"", ""CreatedAt"", ""CreatedBy"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(1, 'Туалетная бумага ""Наждачка""', 'т-б ""Наждачка""', '2025-05-03 15:16:18.712', 1, '2025-05-03 15:16:18.712', 1);
INSERT INTO ""ProductName""
(""Id"", ""Name"", ""ShortName"", ""CreatedAt"", ""CreatedBy"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(2, 'Туалетная бумага ""Зева""', 'т-б ""Зева""', '2025-05-03 15:16:55.174', 1, '2025-05-03 15:16:55.174', 1);
INSERT INTO ""ProductName""
(""Id"", ""Name"", ""ShortName"", ""CreatedAt"", ""CreatedBy"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(3, 'Кроссовки адидас', 'адидас', '2025-05-03 15:17:18.486', 1, '2025-05-03 15:17:18.486', 1);
INSERT INTO ""ProductName""
(""Id"", ""Name"", ""ShortName"", ""CreatedAt"", ""CreatedBy"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(4, 'Кроссовки ньюбеленс', 'ньюбеленс', '2025-05-03 15:17:33.272', 1, '2025-05-03 15:17:33.272', 1);
INSERT INTO ""ProductName""
(""Id"", ""Name"", ""ShortName"", ""CreatedAt"", ""CreatedBy"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(5, 'Кроссовки хани бани', 'банники', '2025-05-03 15:17:48.510', 1, '2025-05-03 15:17:54.368', 1);
";
    
    private const string ProductTypeData = @"
INSERT INTO ""ProductType""
(""Id"", ""Name"", ""ShortName"", ""CreatedAt"", ""CreatedBy"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(1, 'Дом', 'Дом', '2025-05-03 15:06:46.401', 1, '2025-05-03 15:06:46.401', 1);
INSERT INTO ""ProductType""
(""Id"", ""Name"", ""ShortName"", ""CreatedAt"", ""CreatedBy"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(2, 'Бытовая техника', 'Быт', '2025-05-03 15:06:53.184', 1, '2025-05-03 15:06:53.184', 1);
INSERT INTO ""ProductType""
(""Id"", ""Name"", ""ShortName"", ""CreatedAt"", ""CreatedBy"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(3, 'Бытовая химия', 'Быт', '2025-05-03 15:06:59.225', 1, '2025-05-03 15:06:59.225', 1);
INSERT INTO ""ProductType""
(""Id"", ""Name"", ""ShortName"", ""CreatedAt"", ""CreatedBy"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(4, 'Игрушки', 'Игры', '2025-05-03 15:07:08.388', 1, '2025-05-03 15:07:08.388', 1);
INSERT INTO ""ProductType""
(""Id"", ""Name"", ""ShortName"", ""CreatedAt"", ""CreatedBy"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(5, 'Одежда', 'Одежда', '2025-05-03 15:07:17.999', 1, '2025-05-03 15:07:17.999', 1);
INSERT INTO ""ProductType""
(""Id"", ""Name"", ""ShortName"", ""CreatedAt"", ""CreatedBy"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(6, 'Обувь', 'Обувь', '2025-05-03 15:07:24.372', 1, '2025-05-03 15:07:24.372', 1);
INSERT INTO ""ProductType""
(""Id"", ""Name"", ""ShortName"", ""CreatedAt"", ""CreatedBy"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(7, 'Электроника', 'Электроника', '2025-05-03 15:07:39.557', 1, '2025-05-03 15:07:39.557', 1);
";
    
    private const string StorageLocatioData = $@"
INSERT INTO ""StorageLocation""
(""Id"", ""Name"", ""ShortName"", ""CreatedAt"", ""CreatedBy"", ""UpdatedAt"", ""UpdatedBy"", ""Rack"", ""Compartment"", ""Part"")
VALUES(1, NULL, NULL, '2025-05-03 15:05:14.714', 1, '2025-05-03 15:05:14.714', 1, 1, 1, 1);
INSERT INTO ""StorageLocation""
(""Id"", ""Name"", ""ShortName"", ""CreatedAt"", ""CreatedBy"", ""UpdatedAt"", ""UpdatedBy"", ""Rack"", ""Compartment"", ""Part"")
VALUES(2, NULL, NULL, '2025-05-03 15:05:17.593', 1, '2025-05-03 15:05:17.593', 1, 2, 1, 1);
INSERT INTO ""StorageLocation""
(""Id"", ""Name"", ""ShortName"", ""CreatedAt"", ""CreatedBy"", ""UpdatedAt"", ""UpdatedBy"", ""Rack"", ""Compartment"", ""Part"")
VALUES(3, NULL, NULL, '2025-05-03 15:05:20.637', 1, '2025-05-03 15:05:20.637', 1, 3, 1, 1);
INSERT INTO ""StorageLocation""
(""Id"", ""Name"", ""ShortName"", ""CreatedAt"", ""CreatedBy"", ""UpdatedAt"", ""UpdatedBy"", ""Rack"", ""Compartment"", ""Part"")
VALUES(4, NULL, NULL, '2025-05-03 15:05:24.833', 1, '2025-05-03 15:05:24.833', 1, 1, 1, 2);
INSERT INTO ""StorageLocation""
(""Id"", ""Name"", ""ShortName"", ""CreatedAt"", ""CreatedBy"", ""UpdatedAt"", ""UpdatedBy"", ""Rack"", ""Compartment"", ""Part"")
VALUES(5, NULL, NULL, '2025-05-03 15:05:27.548', 1, '2025-05-03 15:05:27.548', 1, 1, 1, 3);
INSERT INTO ""StorageLocation""
(""Id"", ""Name"", ""ShortName"", ""CreatedAt"", ""CreatedBy"", ""UpdatedAt"", ""UpdatedBy"", ""Rack"", ""Compartment"", ""Part"")
VALUES(6, NULL, NULL, '2025-05-03 15:05:29.933', 1, '2025-05-03 15:05:29.933', 1, 1, 2, 1);
INSERT INTO ""StorageLocation""
(""Id"", ""Name"", ""ShortName"", ""CreatedAt"", ""CreatedBy"", ""UpdatedAt"", ""UpdatedBy"", ""Rack"", ""Compartment"", ""Part"")
VALUES(7, NULL, NULL, '2025-05-03 15:05:32.266', 1, '2025-05-03 15:05:32.266', 1, 1, 2, 2);
INSERT INTO ""StorageLocation""
(""Id"", ""Name"", ""ShortName"", ""CreatedAt"", ""CreatedBy"", ""UpdatedAt"", ""UpdatedBy"", ""Rack"", ""Compartment"", ""Part"")
VALUES(8, NULL, NULL, '2025-05-03 15:05:35.551', 1, '2025-05-03 15:05:35.551', 1, 1, 2, 3);
INSERT INTO ""StorageLocation""
(""Id"", ""Name"", ""ShortName"", ""CreatedAt"", ""CreatedBy"", ""UpdatedAt"", ""UpdatedBy"", ""Rack"", ""Compartment"", ""Part"")
VALUES(9, NULL, NULL, '2025-05-03 15:05:39.021', 1, '2025-05-03 15:05:39.021', 1, 2, 2, 1);
INSERT INTO ""StorageLocation""
(""Id"", ""Name"", ""ShortName"", ""CreatedAt"", ""CreatedBy"", ""UpdatedAt"", ""UpdatedBy"", ""Rack"", ""Compartment"", ""Part"")
VALUES(10, NULL, NULL, '2025-05-03 15:05:41.336', 1, '2025-05-03 15:05:41.336', 1, 2, 3, 1);
INSERT INTO ""StorageLocation""
(""Id"", ""Name"", ""ShortName"", ""CreatedAt"", ""CreatedBy"", ""UpdatedAt"", ""UpdatedBy"", ""Rack"", ""Compartment"", ""Part"")
VALUES(11, NULL, NULL, '2025-05-03 15:05:44.297', 1, '2025-05-03 15:05:44.297', 1, 3, 2, 1);
INSERT INTO ""StorageLocation""
(""Id"", ""Name"", ""ShortName"", ""CreatedAt"", ""CreatedBy"", ""UpdatedAt"", ""UpdatedBy"", ""Rack"", ""Compartment"", ""Part"")
VALUES(12, NULL, NULL, '2025-05-03 15:05:48.035', 1, '2025-05-03 15:05:48.035', 1, 3, 2, 2);
INSERT INTO ""StorageLocation""
(""Id"", ""Name"", ""ShortName"", ""CreatedAt"", ""CreatedBy"", ""UpdatedAt"", ""UpdatedBy"", ""Rack"", ""Compartment"", ""Part"")
VALUES(13, NULL, NULL, '2025-05-03 15:05:51.895', 1, '2025-05-03 15:05:51.895', 1, 3, 2, 3);
INSERT INTO ""StorageLocation""
(""Id"", ""Name"", ""ShortName"", ""CreatedAt"", ""CreatedBy"", ""UpdatedAt"", ""UpdatedBy"", ""Rack"", ""Compartment"", ""Part"")
VALUES(14, NULL, NULL, '2025-05-03 15:05:56.370', 1, '2025-05-03 15:05:56.370', 1, 3, 3, 1);";

    private string AuditLogData = @"
INSERT INTO ""AuditLog""
(""Id"", ""Action"", ""EntityName"", ""EntityId"", ""Changes"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(1, 4, 'StorageLocation', 4, '{""operation"":""Create"",""changes"":{""Id"":{""newValue"":-9223372036854774807},""Compartment"":{""newValue"":1},""CreatedAt"":{""newValue"":""2025-05-03T15:05:14.714018Z""},""CreatedBy"":{""newValue"":1},""Name"":{},""Part"":{""newValue"":1},""Rack"":{""newValue"":1},""ShortName"":{},""UpdatedAt"":{""newValue"":""2025-05-03T15:05:14.7140877Z""},""UpdatedBy"":{""newValue"":1}}}', '2025-05-03 15:05:14.818', 1);
INSERT INTO ""AuditLog""
(""Id"", ""Action"", ""EntityName"", ""EntityId"", ""Changes"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(2, 4, 'StorageLocation', 4, '{""operation"":""Create"",""changes"":{""Id"":{""newValue"":-9223372036854774806},""Compartment"":{""newValue"":1},""CreatedAt"":{""newValue"":""2025-05-03T15:05:17.593341Z""},""CreatedBy"":{""newValue"":1},""Name"":{},""Part"":{""newValue"":1},""Rack"":{""newValue"":2},""ShortName"":{},""UpdatedAt"":{""newValue"":""2025-05-03T15:05:17.5933412Z""},""UpdatedBy"":{""newValue"":1}}}', '2025-05-03 15:05:17.594', 1);
INSERT INTO ""AuditLog""
(""Id"", ""Action"", ""EntityName"", ""EntityId"", ""Changes"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(3, 4, 'StorageLocation', 4, '{""operation"":""Create"",""changes"":{""Id"":{""newValue"":-9223372036854774805},""Compartment"":{""newValue"":1},""CreatedAt"":{""newValue"":""2025-05-03T15:05:20.6375414Z""},""CreatedBy"":{""newValue"":1},""Name"":{},""Part"":{""newValue"":1},""Rack"":{""newValue"":3},""ShortName"":{},""UpdatedAt"":{""newValue"":""2025-05-03T15:05:20.6375416Z""},""UpdatedBy"":{""newValue"":1}}}', '2025-05-03 15:05:20.637', 1);
INSERT INTO ""AuditLog""
(""Id"", ""Action"", ""EntityName"", ""EntityId"", ""Changes"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(4, 4, 'StorageLocation', 4, '{""operation"":""Create"",""changes"":{""Id"":{""newValue"":-9223372036854774804},""Compartment"":{""newValue"":1},""CreatedAt"":{""newValue"":""2025-05-03T15:05:24.8338112Z""},""CreatedBy"":{""newValue"":1},""Name"":{},""Part"":{""newValue"":2},""Rack"":{""newValue"":1},""ShortName"":{},""UpdatedAt"":{""newValue"":""2025-05-03T15:05:24.8338113Z""},""UpdatedBy"":{""newValue"":1}}}', '2025-05-03 15:05:24.833', 1);
INSERT INTO ""AuditLog""
(""Id"", ""Action"", ""EntityName"", ""EntityId"", ""Changes"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(5, 4, 'StorageLocation', 4, '{""operation"":""Create"",""changes"":{""Id"":{""newValue"":-9223372036854774803},""Compartment"":{""newValue"":1},""CreatedAt"":{""newValue"":""2025-05-03T15:05:27.5487851Z""},""CreatedBy"":{""newValue"":1},""Name"":{},""Part"":{""newValue"":3},""Rack"":{""newValue"":1},""ShortName"":{},""UpdatedAt"":{""newValue"":""2025-05-03T15:05:27.5487853Z""},""UpdatedBy"":{""newValue"":1}}}', '2025-05-03 15:05:27.548', 1);
INSERT INTO ""AuditLog""
(""Id"", ""Action"", ""EntityName"", ""EntityId"", ""Changes"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(6, 4, 'StorageLocation', 4, '{""operation"":""Create"",""changes"":{""Id"":{""newValue"":-9223372036854774802},""Compartment"":{""newValue"":2},""CreatedAt"":{""newValue"":""2025-05-03T15:05:29.9330909Z""},""CreatedBy"":{""newValue"":1},""Name"":{},""Part"":{""newValue"":1},""Rack"":{""newValue"":1},""ShortName"":{},""UpdatedAt"":{""newValue"":""2025-05-03T15:05:29.933091Z""},""UpdatedBy"":{""newValue"":1}}}', '2025-05-03 15:05:29.933', 1);
INSERT INTO ""AuditLog""
(""Id"", ""Action"", ""EntityName"", ""EntityId"", ""Changes"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(7, 4, 'StorageLocation', 4, '{""operation"":""Create"",""changes"":{""Id"":{""newValue"":-9223372036854774801},""Compartment"":{""newValue"":2},""CreatedAt"":{""newValue"":""2025-05-03T15:05:32.2662354Z""},""CreatedBy"":{""newValue"":1},""Name"":{},""Part"":{""newValue"":2},""Rack"":{""newValue"":1},""ShortName"":{},""UpdatedAt"":{""newValue"":""2025-05-03T15:05:32.2662356Z""},""UpdatedBy"":{""newValue"":1}}}', '2025-05-03 15:05:32.266', 1);
INSERT INTO ""AuditLog""
(""Id"", ""Action"", ""EntityName"", ""EntityId"", ""Changes"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(8, 4, 'StorageLocation', 4, '{""operation"":""Create"",""changes"":{""Id"":{""newValue"":-9223372036854774800},""Compartment"":{""newValue"":2},""CreatedAt"":{""newValue"":""2025-05-03T15:05:35.5514385Z""},""CreatedBy"":{""newValue"":1},""Name"":{},""Part"":{""newValue"":3},""Rack"":{""newValue"":1},""ShortName"":{},""UpdatedAt"":{""newValue"":""2025-05-03T15:05:35.5514386Z""},""UpdatedBy"":{""newValue"":1}}}', '2025-05-03 15:05:35.551', 1);
INSERT INTO ""AuditLog""
(""Id"", ""Action"", ""EntityName"", ""EntityId"", ""Changes"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(9, 4, 'StorageLocation', 4, '{""operation"":""Create"",""changes"":{""Id"":{""newValue"":-9223372036854774799},""Compartment"":{""newValue"":2},""CreatedAt"":{""newValue"":""2025-05-03T15:05:39.0218524Z""},""CreatedBy"":{""newValue"":1},""Name"":{},""Part"":{""newValue"":1},""Rack"":{""newValue"":2},""ShortName"":{},""UpdatedAt"":{""newValue"":""2025-05-03T15:05:39.0218525Z""},""UpdatedBy"":{""newValue"":1}}}', '2025-05-03 15:05:39.022', 1);
INSERT INTO ""AuditLog""
(""Id"", ""Action"", ""EntityName"", ""EntityId"", ""Changes"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(10, 4, 'StorageLocation', 4, '{""operation"":""Create"",""changes"":{""Id"":{""newValue"":-9223372036854774798},""Compartment"":{""newValue"":3},""CreatedAt"":{""newValue"":""2025-05-03T15:05:41.3362116Z""},""CreatedBy"":{""newValue"":1},""Name"":{},""Part"":{""newValue"":1},""Rack"":{""newValue"":2},""ShortName"":{},""UpdatedAt"":{""newValue"":""2025-05-03T15:05:41.3362118Z""},""UpdatedBy"":{""newValue"":1}}}', '2025-05-03 15:05:41.336', 1);
INSERT INTO ""AuditLog""
(""Id"", ""Action"", ""EntityName"", ""EntityId"", ""Changes"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(11, 4, 'StorageLocation', 4, '{""operation"":""Create"",""changes"":{""Id"":{""newValue"":-9223372036854774797},""Compartment"":{""newValue"":2},""CreatedAt"":{""newValue"":""2025-05-03T15:05:44.2976446Z""},""CreatedBy"":{""newValue"":1},""Name"":{},""Part"":{""newValue"":1},""Rack"":{""newValue"":3},""ShortName"":{},""UpdatedAt"":{""newValue"":""2025-05-03T15:05:44.2976447Z""},""UpdatedBy"":{""newValue"":1}}}', '2025-05-03 15:05:44.297', 1);
INSERT INTO ""AuditLog""
(""Id"", ""Action"", ""EntityName"", ""EntityId"", ""Changes"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(12, 4, 'StorageLocation', 4, '{""operation"":""Create"",""changes"":{""Id"":{""newValue"":-9223372036854774796},""Compartment"":{""newValue"":2},""CreatedAt"":{""newValue"":""2025-05-03T15:05:48.0355853Z""},""CreatedBy"":{""newValue"":1},""Name"":{},""Part"":{""newValue"":2},""Rack"":{""newValue"":3},""ShortName"":{},""UpdatedAt"":{""newValue"":""2025-05-03T15:05:48.0355854Z""},""UpdatedBy"":{""newValue"":1}}}', '2025-05-03 15:05:48.035', 1);
INSERT INTO ""AuditLog""
(""Id"", ""Action"", ""EntityName"", ""EntityId"", ""Changes"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(13, 4, 'StorageLocation', 4, '{""operation"":""Create"",""changes"":{""Id"":{""newValue"":-9223372036854774795},""Compartment"":{""newValue"":2},""CreatedAt"":{""newValue"":""2025-05-03T15:05:51.8958097Z""},""CreatedBy"":{""newValue"":1},""Name"":{},""Part"":{""newValue"":3},""Rack"":{""newValue"":3},""ShortName"":{},""UpdatedAt"":{""newValue"":""2025-05-03T15:05:51.8958098Z""},""UpdatedBy"":{""newValue"":1}}}', '2025-05-03 15:05:51.896', 1);
INSERT INTO ""AuditLog""
(""Id"", ""Action"", ""EntityName"", ""EntityId"", ""Changes"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(14, 4, 'StorageLocation', 4, '{""operation"":""Create"",""changes"":{""Id"":{""newValue"":-9223372036854774794},""Compartment"":{""newValue"":3},""CreatedAt"":{""newValue"":""2025-05-03T15:05:56.3709177Z""},""CreatedBy"":{""newValue"":1},""Name"":{},""Part"":{""newValue"":1},""Rack"":{""newValue"":3},""ShortName"":{},""UpdatedAt"":{""newValue"":""2025-05-03T15:05:56.3709179Z""},""UpdatedBy"":{""newValue"":1}}}', '2025-05-03 15:05:56.371', 1);
INSERT INTO ""AuditLog""
(""Id"", ""Action"", ""EntityName"", ""EntityId"", ""Changes"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(15, 4, 'ProductType', 3, '{""operation"":""Create"",""changes"":{""Id"":{""newValue"":-9223372036854774807},""CreatedAt"":{""newValue"":""2025-05-03T15:06:46.4011646Z""},""CreatedBy"":{""newValue"":1},""Name"":{""newValue"":""Дом""},""ShortName"":{""newValue"":""Дом""},""UpdatedAt"":{""newValue"":""2025-05-03T15:06:46.4011649Z""},""UpdatedBy"":{""newValue"":1}}}', '2025-05-03 15:06:46.413', 1);
INSERT INTO ""AuditLog""
(""Id"", ""Action"", ""EntityName"", ""EntityId"", ""Changes"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(16, 4, 'ProductType', 3, '{""operation"":""Create"",""changes"":{""Id"":{""newValue"":-9223372036854774806},""CreatedAt"":{""newValue"":""2025-05-03T15:06:53.1849803Z""},""CreatedBy"":{""newValue"":1},""Name"":{""newValue"":""Бытовая техника""},""ShortName"":{""newValue"":""Быт""},""UpdatedAt"":{""newValue"":""2025-05-03T15:06:53.1849804Z""},""UpdatedBy"":{""newValue"":1}}}', '2025-05-03 15:06:53.185', 1);
INSERT INTO ""AuditLog""
(""Id"", ""Action"", ""EntityName"", ""EntityId"", ""Changes"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(17, 4, 'ProductType', 3, '{""operation"":""Create"",""changes"":{""Id"":{""newValue"":-9223372036854774805},""CreatedAt"":{""newValue"":""2025-05-03T15:06:59.2258353Z""},""CreatedBy"":{""newValue"":1},""Name"":{""newValue"":""Бытовая химия""},""ShortName"":{""newValue"":""Быт""},""UpdatedAt"":{""newValue"":""2025-05-03T15:06:59.2258354Z""},""UpdatedBy"":{""newValue"":1}}}', '2025-05-03 15:06:59.226', 1);
INSERT INTO ""AuditLog""
(""Id"", ""Action"", ""EntityName"", ""EntityId"", ""Changes"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(18, 4, 'ProductType', 3, '{""operation"":""Create"",""changes"":{""Id"":{""newValue"":-9223372036854774804},""CreatedAt"":{""newValue"":""2025-05-03T15:07:08.3882171Z""},""CreatedBy"":{""newValue"":1},""Name"":{""newValue"":""Игрушки""},""ShortName"":{""newValue"":""Игры""},""UpdatedAt"":{""newValue"":""2025-05-03T15:07:08.3882171Z""},""UpdatedBy"":{""newValue"":1}}}', '2025-05-03 15:07:08.388', 1);
INSERT INTO ""AuditLog""
(""Id"", ""Action"", ""EntityName"", ""EntityId"", ""Changes"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(19, 4, 'ProductType', 3, '{""operation"":""Create"",""changes"":{""Id"":{""newValue"":-9223372036854774803},""CreatedAt"":{""newValue"":""2025-05-03T15:07:17.999558Z""},""CreatedBy"":{""newValue"":1},""Name"":{""newValue"":""Одежда""},""ShortName"":{""newValue"":""Одежда""},""UpdatedAt"":{""newValue"":""2025-05-03T15:07:17.9995581Z""},""UpdatedBy"":{""newValue"":1}}}', '2025-05-03 15:07:17.999', 1);
INSERT INTO ""AuditLog""
(""Id"", ""Action"", ""EntityName"", ""EntityId"", ""Changes"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(20, 4, 'ProductType', 3, '{""operation"":""Create"",""changes"":{""Id"":{""newValue"":-9223372036854774802},""CreatedAt"":{""newValue"":""2025-05-03T15:07:24.372644Z""},""CreatedBy"":{""newValue"":1},""Name"":{""newValue"":""Обувь""},""ShortName"":{""newValue"":""Обувь""},""UpdatedAt"":{""newValue"":""2025-05-03T15:07:24.372644Z""},""UpdatedBy"":{""newValue"":1}}}', '2025-05-03 15:07:24.372', 1);
INSERT INTO ""AuditLog""
(""Id"", ""Action"", ""EntityName"", ""EntityId"", ""Changes"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(21, 4, 'ProductType', 3, '{""operation"":""Create"",""changes"":{""Id"":{""newValue"":-9223372036854774801},""CreatedAt"":{""newValue"":""2025-05-03T15:07:39.5575897Z""},""CreatedBy"":{""newValue"":1},""Name"":{""newValue"":""Электроника""},""ShortName"":{""newValue"":""Электроника""},""UpdatedAt"":{""newValue"":""2025-05-03T15:07:39.55759Z""},""UpdatedBy"":{""newValue"":1}}}', '2025-05-03 15:07:39.558', 1);
INSERT INTO ""AuditLog""
(""Id"", ""Action"", ""EntityName"", ""EntityId"", ""Changes"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(22, 4, 'ProductName', 5, '{""operation"":""Create"",""changes"":{""Id"":{""newValue"":-9223372036854774807},""CreatedAt"":{""newValue"":""2025-05-03T15:16:18.7121514Z""},""CreatedBy"":{""newValue"":1},""Name"":{""newValue"":""Туалетная бумага \""Наждачка\""""},""ShortName"":{""newValue"":""т-б \""Наждачка\""""},""UpdatedAt"":{""newValue"":""2025-05-03T15:16:18.7123513Z""},""UpdatedBy"":{""newValue"":1}}}', '2025-05-03 15:16:21.967', 1);
INSERT INTO ""AuditLog""
(""Id"", ""Action"", ""EntityName"", ""EntityId"", ""Changes"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(23, 4, 'ProductName', 5, '{""operation"":""Create"",""changes"":{""Id"":{""newValue"":-9223372036854774806},""CreatedAt"":{""newValue"":""2025-05-03T15:16:55.1745771Z""},""CreatedBy"":{""newValue"":1},""Name"":{""newValue"":""Туалетная бумага \""Зева\""""},""ShortName"":{""newValue"":""т-б \""Зева\""""},""UpdatedAt"":{""newValue"":""2025-05-03T15:16:55.1745774Z""},""UpdatedBy"":{""newValue"":1}}}', '2025-05-03 15:16:55.176', 1);
INSERT INTO ""AuditLog""
(""Id"", ""Action"", ""EntityName"", ""EntityId"", ""Changes"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(24, 4, 'ProductName', 5, '{""operation"":""Create"",""changes"":{""Id"":{""newValue"":-9223372036854774805},""CreatedAt"":{""newValue"":""2025-05-03T15:17:18.4861741Z""},""CreatedBy"":{""newValue"":1},""Name"":{""newValue"":""Кроссовки адидас""},""ShortName"":{""newValue"":""адидас""},""UpdatedAt"":{""newValue"":""2025-05-03T15:17:18.4861742Z""},""UpdatedBy"":{""newValue"":1}}}', '2025-05-03 15:17:18.486', 1);
INSERT INTO ""AuditLog""
(""Id"", ""Action"", ""EntityName"", ""EntityId"", ""Changes"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(25, 4, 'ProductName', 5, '{""operation"":""Create"",""changes"":{""Id"":{""newValue"":-9223372036854774804},""CreatedAt"":{""newValue"":""2025-05-03T15:17:33.2727216Z""},""CreatedBy"":{""newValue"":1},""Name"":{""newValue"":""Кроссовки ньюбеленс""},""ShortName"":{""newValue"":""ньюбеленс""},""UpdatedAt"":{""newValue"":""2025-05-03T15:17:33.2727217Z""},""UpdatedBy"":{""newValue"":1}}}', '2025-05-03 15:17:33.272', 1);
INSERT INTO ""AuditLog""
(""Id"", ""Action"", ""EntityName"", ""EntityId"", ""Changes"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(26, 4, 'ProductName', 5, '{""operation"":""Create"",""changes"":{""Id"":{""newValue"":-9223372036854774803},""CreatedAt"":{""newValue"":""2025-05-03T15:17:48.5102357Z""},""CreatedBy"":{""newValue"":1},""Name"":{""newValue"":""Кроссовки хани бани""},""ShortName"":{""newValue"":""банники андрея""},""UpdatedAt"":{""newValue"":""2025-05-03T15:17:48.5102359Z""},""UpdatedBy"":{""newValue"":1}}}', '2025-05-03 15:17:48.510', 1);
INSERT INTO ""AuditLog""
(""Id"", ""Action"", ""EntityName"", ""EntityId"", ""Changes"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(27, 3, 'ProductName', 5, '{""operation"":""Update"",""changes"":{""Id"":{""oldValue"":5,""newValue"":5},""CreatedAt"":{""oldValue"":""2025-05-03T15:17:48.510235"",""newValue"":""2025-05-03T15:17:48.510235Z""},""CreatedBy"":{""oldValue"":1,""newValue"":1},""Name"":{""oldValue"":""Кроссовки хани бани"",""newValue"":""Кроссовки хани бани""},""ShortName"":{""oldValue"":""банники андрея"",""newValue"":""банники""},""UpdatedAt"":{""oldValue"":""2025-05-03T15:17:48.510235"",""newValue"":""2025-05-03T15:17:54.3689897Z""},""UpdatedBy"":{""oldValue"":1,""newValue"":1}}}', '2025-05-03 15:17:54.370', 1);
INSERT INTO ""AuditLog""
(""Id"", ""Action"", ""EntityName"", ""EntityId"", ""Changes"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(28, 3, 'ProductType', 3, '{""operation"":""Update"",""changes"":{""Id"":{""oldValue"":7,""newValue"":7},""CreatedAt"":{""oldValue"":""2025-05-03T15:07:39.557589"",""newValue"":""2025-05-03T15:07:39.557589Z""},""CreatedBy"":{""oldValue"":1,""newValue"":1},""Name"":{""oldValue"":""Электроника"",""newValue"":""Электроника""},""ShortName"":{""oldValue"":""Электроника"",""newValue"":""Эл.""},""UpdatedAt"":{""oldValue"":""2025-05-03T15:07:39.55759"",""newValue"":""2025-05-03T15:18:07.6826372Z""},""UpdatedBy"":{""oldValue"":1,""newValue"":1}}}', '2025-05-03 15:18:07.687', 1);
INSERT INTO ""AuditLog""
(""Id"", ""Action"", ""EntityName"", ""EntityId"", ""Changes"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(29, 2, 'StorageLocation', 4, '{""operation"":""Delete"",""changes"":{""Id"":{""oldValue"":5},""Compartment"":{""oldValue"":1},""CreatedAt"":{""oldValue"":""2025-05-03T15:05:27.548785""},""CreatedBy"":{""oldValue"":1},""Name"":{},""Part"":{""oldValue"":3},""Rack"":{""oldValue"":1},""ShortName"":{},""UpdatedAt"":{""oldValue"":""2025-05-03T15:05:27.548785""},""UpdatedBy"":{""oldValue"":1}}}', '2025-05-03 15:18:20.471', 1);
INSERT INTO ""AuditLog""
(""Id"", ""Action"", ""EntityName"", ""EntityId"", ""Changes"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(30, 2, 'StorageLocation', 4, '{""operation"":""Delete"",""changes"":{""Id"":{""oldValue"":4},""Compartment"":{""oldValue"":1},""CreatedAt"":{""oldValue"":""2025-05-03T15:05:24.833811""},""CreatedBy"":{""oldValue"":1},""Name"":{},""Part"":{""oldValue"":2},""Rack"":{""oldValue"":1},""ShortName"":{},""UpdatedAt"":{""oldValue"":""2025-05-03T15:05:24.833811""},""UpdatedBy"":{""oldValue"":1}}}', '2025-05-03 15:18:22.214', 1);
INSERT INTO ""AuditLog""
(""Id"", ""Action"", ""EntityName"", ""EntityId"", ""Changes"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(31, 4, 'Product', 2, '{""operation"":""Create"",""changes"":{""Id"":{""newValue"":-9223372036854774807},""CreatedAt"":{""newValue"":""2025-05-03T15:25:48.5496883Z""},""CreatedBy"":{""newValue"":1},""Description"":{},""Name"":{},""ProductNameId"":{""newValue"":3},""ProductTypeId"":{""newValue"":6},""Quantity"":{""newValue"":1},""ShortName"":{},""StorageLocationId"":{""newValue"":1},""UpdatedAt"":{""newValue"":""2025-05-03T15:25:48.5602925Z""},""UpdatedBy"":{""newValue"":1}}}', '2025-05-03 15:25:52.223', 1);
INSERT INTO ""AuditLog""
(""Id"", ""Action"", ""EntityName"", ""EntityId"", ""Changes"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(32, 4, 'Product', 2, '{""operation"":""Create"",""changes"":{""Id"":{""newValue"":-9223372036854774806},""CreatedAt"":{""newValue"":""2025-05-03T15:26:57.1556082Z""},""CreatedBy"":{""newValue"":1},""Description"":{},""Name"":{},""ProductNameId"":{""newValue"":2},""ProductTypeId"":{""newValue"":3},""Quantity"":{""newValue"":12},""ShortName"":{},""StorageLocationId"":{""newValue"":3},""UpdatedAt"":{""newValue"":""2025-05-03T15:26:57.1556091Z""},""UpdatedBy"":{""newValue"":1}}}', '2025-05-03 15:26:57.157', 1);
INSERT INTO ""AuditLog""
(""Id"", ""Action"", ""EntityName"", ""EntityId"", ""Changes"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(33, 4, 'Product', 2, '{""operation"":""Create"",""changes"":{""Id"":{""newValue"":-9223372036854774805},""CreatedAt"":{""newValue"":""2025-05-03T15:27:09.8477779Z""},""CreatedBy"":{""newValue"":1},""Description"":{},""Name"":{},""ProductNameId"":{""newValue"":1},""ProductTypeId"":{""newValue"":3},""Quantity"":{""newValue"":4},""ShortName"":{},""StorageLocationId"":{""newValue"":11},""UpdatedAt"":{""newValue"":""2025-05-03T15:27:09.847778Z""},""UpdatedBy"":{""newValue"":1}}}', '2025-05-03 15:27:09.848', 1);
INSERT INTO ""AuditLog""
(""Id"", ""Action"", ""EntityName"", ""EntityId"", ""Changes"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(34, 4, 'Product', 2, '{""operation"":""Create"",""changes"":{""Id"":{""newValue"":-9223372036854774804},""CreatedAt"":{""newValue"":""2025-05-03T15:27:21.2466683Z""},""CreatedBy"":{""newValue"":1},""Description"":{},""Name"":{},""ProductNameId"":{""newValue"":4},""ProductTypeId"":{""newValue"":6},""Quantity"":{""newValue"":2},""ShortName"":{},""StorageLocationId"":{""newValue"":1},""UpdatedAt"":{""newValue"":""2025-05-03T15:27:21.2466684Z""},""UpdatedBy"":{""newValue"":1}}}', '2025-05-03 15:27:21.246', 1);
INSERT INTO ""AuditLog""
(""Id"", ""Action"", ""EntityName"", ""EntityId"", ""Changes"", ""UpdatedAt"", ""UpdatedBy"")
VALUES(35, 4, 'Product', 2, '{""operation"":""Create"",""changes"":{""Id"":{""newValue"":-9223372036854774803},""CreatedAt"":{""newValue"":""2025-05-03T15:27:35.3162928Z""},""CreatedBy"":{""newValue"":1},""Description"":{},""Name"":{},""ProductNameId"":{""newValue"":5},""ProductTypeId"":{""newValue"":6},""Quantity"":{""newValue"":6},""ShortName"":{},""StorageLocationId"":{""newValue"":6},""UpdatedAt"":{""newValue"":""2025-05-03T15:27:35.3162931Z""},""UpdatedBy"":{""newValue"":1}}}', '2025-05-03 15:27:35.316', 1);
";

    public override void Up()
    {
        var query = $@"
{ProductNameData}
{ProductTypeData}
{StorageLocatioData}
{ProductData}
{AuditLogData}
";

        DatabaseConnection.Execute(query);
    }
    
    public override void Down()
    {
        var query = @"";
        
        DatabaseConnection.Execute(query);
    }
}